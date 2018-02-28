using System;
using Newtonsoft.Json;

namespace Shared
{
    public class SalesOrder2
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ponumber")]
        public string PurchaseOrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public string AccountNumber { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxAmt { get; set; }

        public decimal Freight { get; set; }

        public decimal TotalDue { get; set; }

        public decimal DiscountAmt { get; set; }

        public SalesOrderDetail2[] Items { get; set; }
    }
}