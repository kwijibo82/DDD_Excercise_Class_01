namespace Shared
{
    public class SalesOrderDetailVO
    {
        public SalesOrderDetailVO(int orderQty, int productId, decimal unitPrice, decimal lineTotal)
        {
            OrderQty = orderQty;
            ProductId = productId;
            UnitPrice = unitPrice;
            LineTotal = lineTotal;
        }

        public int OrderQty { get; }
        public int ProductId { get; }
        public decimal UnitPrice { get; }
        public decimal LineTotal { get; }
    }

    public class SalesOrderDetail
    {
        public int OrderQty { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}