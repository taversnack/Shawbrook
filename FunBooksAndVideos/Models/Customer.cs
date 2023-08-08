using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
