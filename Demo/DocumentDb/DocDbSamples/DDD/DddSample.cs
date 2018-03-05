using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Shared;

namespace DocDbSamples.DDD
{
    public class DddSample
    {
        private static readonly string databaseName = "samples";
        private static readonly string collectionName = "document-samples";

        // Read config
        private static readonly string endpointUrl = "https://ddd-loc-euwe-main.documents.azure.com:443/";
        private static readonly string authorizationKey = "ZHUt4wCW1EqsAyKCv0hDkP6ULkPf8gm3y0Qjrtr0nmeHKOv1k9iJdv76sCS1pZvPgQvw6O3snizags7xPBBVoQ==";

        //Reusable instance of DocumentClient which represents the connection to a DocumentDB endpoint
        private static DocumentClient _client;

        public static void RunSample()
        {
            try
            {
                using (_client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
                {
                    Initialize().Wait();
                    RunStrongTypeDocumentsDemo().Wait();
                    RunDocumentDemo().Wait();
                }
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

        private static async Task RunDocumentDemo()
        {
            Guid key = Guid.NewGuid();
            SalesOrderAggregate salesOrder = GetAggregateSample(key, new Random().Next(5, 15));
            await UpsertDocumentTypeAsync(salesOrder);
            SalesOrderAggregate salesOrderRead = await ReadDocumentAsync(key.ToString());
        }

        private static async Task<SalesOrderAggregate> ReadDocumentAsync(string key)
        {
            var documentUri = UriFactory.CreateDocumentUri(databaseName, collectionName, key);

            DocumentResponse<SalesOrderDocument> response = await _client.ReadDocumentAsync<SalesOrderDocument>(documentUri);
            Console.WriteLine($"Read SalesOrderDocument - Request charge {response.RequestCharge}");
            return new SalesOrderAggregate(Guid.Parse( response.Document.Id)
                , response.Document.PurchaseOrderNumber
                , response.Document.TimeToLive
                , response.Document.OrderDate
                , response.Document.ShippedDate
                , response.Document.SubTotal
                , response.Document.TaxAmount
                , response.Document.Freight
                , response.Document.TotalDue, response.Document.AccountNumber, response.Document.Items);
        }

        private static async Task RunStrongTypeDocumentsDemo()
        {
            //string key = "SalesOrder1";
            Guid key = Guid.NewGuid();
            SalesOrderAggregate salesOrder = GetAggregateSample(key, new Random().Next(5, 15));
            await UpsertStrongTypeAsync(salesOrder);
            SalesOrderAggregate salesOrderRead = await ReadStrongTypeFromDocumentAsync(key.ToString());
        }

        private static async Task UpsertDocumentTypeAsync(SalesOrderAggregate salesOrder)
        {
            SalesOrderDocument document = new SalesOrderDocument
            {
                Id = salesOrder.Id.ToString(),
                AccountNumber = salesOrder.AccountNumber,
                Freight = salesOrder.Freight,
                TimeToLive = salesOrder.TimeToLive,
                OrderDate = salesOrder.OrderDate,
                Items = salesOrder.Items,
                PurchaseOrderNumber = salesOrder.PurchaseOrderNumber,
                ShippedDate = salesOrder.ShippedDate,
                SubTotal = salesOrder.SubTotal,
                TaxAmount = salesOrder.TaxAmount,
                TotalDue = salesOrder.TotalDue
            };

            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);
            Console.WriteLine("\n1.1 - Creating documents");
            var response = await _client.UpsertDocumentAsync(collectionUri, document);
            Console.WriteLine($"Creating document type request charge {response.RequestCharge}");
        }

        private static async Task UpsertStrongTypeAsync(SalesOrderAggregate salesOrder)
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);
            Console.WriteLine("\n1.1 - Creating documents");
            var response = await _client.UpsertDocumentAsync(collectionUri, salesOrder);
            Console.WriteLine($"Creating strong type charge {response.RequestCharge}");
        }

        private static async Task<SalesOrderAggregate> ReadStrongTypeFromDocumentAsync(string id)
        {
            ResourceResponse<Document> response = await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, id));
            Console.WriteLine("Read strong type by Id {0}", response.RequestCharge);
            return (SalesOrderAggregate)(dynamic)response.Resource;
        }

        private static SalesOrderAggregate GetAggregateSample(Guid documentId, int detailCount)
        {
            return new SalesOrderAggregate(documentId, "algo", 60 * 60 * 24 * 30, new DateTime(2005, 7, 1), DateTime.MinValue, 419.4589m, 12.5838m,
                472.3108m, 985.018m, "account1", Enumerable.Range(0, detailCount).Select(i => new SalesOrderDetailVO(i, i, i, i)));

            //{
            //    Id = documentId,
            //    AccountNumber = "Account1",
            //    PurchaseOrderNumber = "PO18009186470",
            //    OrderDate = ,
            //    SubTotal = 419.4589m,
            //    TaxAmount = 12.5838m,
            //    Freight = 472.3108m,
            //    TotalDue = 985.018m,
            //    Items = new[]
            //    {
            //        new SalesOrderDetail
            //        {
            //            OrderQty = 1,
            //            ProductId = 760,
            //            UnitPrice = 419.4589m,
            //            LineTotal = 419.4589m
            //        }
            //    },
            //    TimeToLive = 60 * 60 * 24 * 30,
            //};

        }
        private static async Task Initialize()
        {
            await _client.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

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
            await _client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(databaseName),
                collectionDefinition,
                new RequestOptions { OfferThroughput = 400 });
        }
    }
}
