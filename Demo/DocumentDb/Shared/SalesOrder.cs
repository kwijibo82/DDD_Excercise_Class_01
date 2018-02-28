using System;
using Newtonsoft.Json;

namespace Shared
{
    public class SalesOrder
    {
        //You can use JsonProperty attributes to control how your objects are
        //handled by the Json Serializer/Deserializer
        //Any of the supported JSON.NET attributes here are supported, including the use of JsonConverters
        //if you really want fine grained control over the process

        //Here we are using JsonProperty to control how the Id property is passed over the wire
        //In this case, we're just making it a lowerCase string but you could entirely rename it
        //like we do with PurchaseOrderNumber below
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ponumber")]
        public string PurchaseOrderNumber { get; set; }

        // used to set expiration policy
        [JsonProperty(PropertyName = "ttl", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeToLive { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string AccountNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public SalesOrderDetail[] Items { get; set; }
    }
}
