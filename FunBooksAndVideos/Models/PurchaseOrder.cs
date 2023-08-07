namespace FunBooksAndVideos.Models
{
    public class PurchaseOrder
    {
        public int POId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
        public string? ShippingSlip { get; set; } = "";
    }
}
