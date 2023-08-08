namespace FunBooksAndVideos.Models
{
    public class MembershipStatus
    {
        public int CustomerId { get; set; }
        public int MembershipId { get; set; }
        public bool IsActive { get; set; }
    }
}
