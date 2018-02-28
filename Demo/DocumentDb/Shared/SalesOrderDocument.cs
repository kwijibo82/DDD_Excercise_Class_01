using System;
using Microsoft.Azure.Documents;

namespace Shared
{
    /// <summary>
    /// SalesOrderDocument extends the Microsoft.Azure.Documents.Resource class
    /// This gives you access to internal properties of a Resource such as ETag, SelfLink, Id etc.
    /// When working with objects extending from Resource you get the benefit of not having to 
    /// dynamically cast between Document and your POCO.
    /// </summary>
    public class SalesOrderDocument : Document
    {
        public SalesOrderDocument()
        {
        }

        public string PurchaseOrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string AccountNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public SalesOrderDetail[] Items { get; set; }
    }
}