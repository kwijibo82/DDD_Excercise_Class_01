using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using System.Collections.Generic;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;
using Microsoft.Azure.Documents;
using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades;
using Microsoft.Azure.Documents.Client;

namespace EnvioBoundedContext.Infraestructure.Data
{
    public class EnvioRepositoryDocDB : EnvioRepository
    {
        private const string databaseName = "EnviosDB";
        private const string collectionName = "Envios";

        private const string endpointUrl = "https://ddd-loc-euwe-main.documents.azure.com:443/";
        private const string authorizationKey = "ZHUt4wCW1EqsAyKCv0hDkP6ULkPf8gm3y0Qjrtr0nmeHKOv1k9iJdv76sCS1pZvPgQvw6O3snizags7xPBBVoQ==";

        public EnvioRepositoryDocDB()
        {
            using (var client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {
                Initialize(client).Wait();
            }
        }

        public async Task<Envio> GetByIdAsync(EnvioId id)
        {
            using (var client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {
                var documentUri = UriFactory.CreateDocumentUri(databaseName, collectionName, id.Key.ToString());
                DocumentResponse<EnvioDocument> response = await client.ReadDocumentAsync<EnvioDocument>(documentUri);

                return new Envio(Guid.Parse(response.Document.Id)
                    , response.Document.EnvioState
                    , response.Document.ServicioId
                    , response.Document.Remitente
                    , response.Document.Destinatario
                    , response.Document.DireccionEntrega
                    , response.Document.DireccionRecogida
                    , response.Document.Bultos);
            }

        }

        public Task SaveAsync(Envio entity)
        {
            throw new NotImplementedException();
        }

        private async Task Initialize(DocumentClient client)
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

            // We create a partitioned collection here which needs a partition key. Partitioned collections
            // can be created with very high values of provisioned throughput (up to OfferThroughput = 250,000)
            // and used to store up to 250 GB of data. You can also skip specifying a partition key to create
            // single partition collections that store up to 10 GB of data.
            DocumentCollection collectionDefinition = new DocumentCollection
            {
                Id = collectionName
            };

            // Use the recommended indexing policy which supports range queries/sorting on strings
            collectionDefinition.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

            // Create with a throughput of 1000 RU/s
            await client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(databaseName),
                collectionDefinition,
                new RequestOptions { OfferThroughput = 400 });
        }
    }

    public class EnvioDocument : Resource
    {
        public EnvioState EnvioState { get; set; }
        public ServicioId ServicioId { get; set; }
        public EnvioPersona Remitente { get; set; }
        public EnvioPersona Destinatario { get; set; }
        public Direccion DireccionEntrega { get; set; }
        public Direccion DireccionRecogida { get; set; }
        public IEnumerable<Bulto> Bultos { get; set; }
    }
}