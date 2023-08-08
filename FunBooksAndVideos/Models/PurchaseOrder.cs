using FunBooksAndVideos.Processors;

namespace FunBooksAndVideos.Models
{
    public class PurchaseOrder
    {
        private static int poCount { get; set; } = 0;
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ItemLine> ItemLines { get; set; } = new List<ItemLine>();

        public PurchaseOrder() { this.OrderId = ++poCount; }

        public void AddItemLine(ItemLine itemLine)
        {
            ItemLines.Add(itemLine);
        }

        public void ProcessOrder()
        {
            var processor = new PurchaseOrderProcessor();
            processor.ProcessPurchaseOrder(this);
        }

    }
}
