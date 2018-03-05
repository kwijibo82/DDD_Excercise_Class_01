using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shared
{
    public class SalesOrderAggregate
    {
        private readonly IList<SalesOrderDetailVO> _details;

        public SalesOrderAggregate(Guid id, string purchaseOrderNumber, int? ttl, DateTime orderDate, DateTime shippedDate, decimal subTotal, decimal taxAmount, decimal freight, decimal totalDue, string accountNumber, IEnumerable<SalesOrderDetailVO> items)
        {
            Id = id;
            _details = new List<SalesOrderDetailVO>(items);
            OrderDate = orderDate;
            ShippedDate = shippedDate;
            SubTotal = subTotal;
            TaxAmount = taxAmount;
            Freight = freight;
            TotalDue = totalDue;
            AccountNumber = accountNumber;
            PurchaseOrderNumber = purchaseOrderNumber;
            TimeToLive = ttl;
        }
        //Any of the supported JSON.NET attributes here are supported, including the use of JsonConverters
        //if you really want fine grained control over the process
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; }
        public string PurchaseOrderNumber { get; }
        [JsonProperty(PropertyName = "ttl", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeToLive { get; }
        public DateTime OrderDate { get; }
        public DateTime ShippedDate { get; }
        public string AccountNumber { get; }
        public decimal SubTotal { get; }
        public decimal TaxAmount { get; }
        public decimal Freight { get; }
        public decimal TotalDue { get; }

        public IEnumerable<SalesOrderDetailVO> Items => _details;
    }
}