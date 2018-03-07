using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace EnvioBoundedContext.Infraestructure.Data
{
    public class EnvioRepositoryDocDB : EnvioRepository
    {
        private const string DatabaseName = "EnviosDB";
        private const string CollectionName = "Envios";

        private const string EndpointUrl = "https://ddd-loc-euwe-main.documents.azure.com:443/";
        private const string AuthorizationKey = "ZHUt4wCW1EqsAyKCv0hDkP6ULkPf8gm3y0Qjrtr0nmeHKOv1k9iJdv76sCS1pZvPgQvw6O3snizags7xPBBVoQ==";

        public EnvioRepositoryDocDB()
        {
            using (var client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey))
            {
                Initialize(client).Wait();
            }
        }

        public async Task<Envio> GetByIdAsync(EnvioId id)
        {
            using (var client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey))
            {
                var documentUri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, id.Key.ToString());
                DocumentResponse<EnvioDocument> response = await client.ReadDocumentAsync<EnvioDocument>(documentUri);

                return new Envio(Guid.Parse(response.Document.Id)
                    , EnvioState.FromValue<EnvioState>(response.Document.EnvioStateKey)
                    , response.Document.ServicioId
                    , response.Document.Remitente
                    , response.Document.Destinatario
                    , response.Document.DireccionEntrega
                    , response.Document.DireccionRecogida
                    , response.Document.Bultos);
            }

        }

        public async Task SaveAsync(Envio agregateRoot)
        {
            using (var client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey))
            {
                EnvioDocument envio = new EnvioDocument()
                {
                    Id = agregateRoot.Id.Key.ToString(),
                    EnvioStateKey = agregateRoot.EnvioState.Id,
                    ServicioId = agregateRoot.ServicioId,
                    Remitente = agregateRoot.Remitente,
                    Destinatario = agregateRoot.Destinatario,
                    DireccionEntrega = agregateRoot.DireccionEntrega,
                    DireccionRecogida = agregateRoot.DireccionRecogida,
                    Bultos = agregateRoot.Bultos
                };

                Uri collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
                var response = await client.UpsertDocumentAsync(collectionUri, envio);
            }
        }

        public async Task GetAll()
        {
            using (var client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey))
            {
                foreach (Document document in await client.ReadDocumentFeedAsync(
                    UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName),
                    new FeedOptions {MaxItemCount = 10}))
                {
                    Console.WriteLine(document);
                }
            }
        }
        private async Task Initialize(DocumentClient client)
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = DatabaseName });

            // We create a partitioned collection here which needs a partition key. Partitioned collections
            // can be created with very high values of provisioned throughput (up to OfferThroughput = 250,000)
            // and used to store up to 250 GB of data. You can also skip specifying a partition key to create
            // single partition collections that store up to 10 GB of data.
            DocumentCollection collectionDefinition = new DocumentCollection
            {
                Id = CollectionName
            };

            // Use the recommended indexing policy which supports range queries/sorting on strings
            collectionDefinition.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

            // Create with a throughput of 1000 RU/s
            await client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(DatabaseName),
                collectionDefinition,
                new RequestOptions { OfferThroughput = 400 });
        }
    }
}