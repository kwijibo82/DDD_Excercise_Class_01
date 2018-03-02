using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Documents;

namespace Shared
{
    /// <summary>
    /// SalesOrderDocument extends the Microsoft.Azure.Documents.Resource class
    /// This gives you access to internal properties of a Resource such as ETag, SelfLink, Id etc.
    /// When working with objects extending from Resource you get the benefit of not having to 
    /// dynamically cast between Document and your POCO.
    /// </summary>
    public class SalesOrderDocument : Resource
    {
        public string PurchaseOrderNumber { get; set; }
        public int? TimeToLive { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string AccountNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public IEnumerable<SalesOrderDetailVO> Items { get; set; }
    }
}