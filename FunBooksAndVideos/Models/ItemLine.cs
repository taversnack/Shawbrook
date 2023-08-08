namespace FunBooksAndVideos.Models
{
    public class ItemLine
    {
        public int ItemLineId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? MembershipId { get; set; } // Nullable int for optional membership

        public Product Product { get; set; }
        public Membership Membership { get; set; }
    }
}
