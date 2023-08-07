namespace FunBooksAndVideos.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public List<Membership> Memberships { get; set; } = new List<Membership>();

        public Customer(int id)
        {
            Id = id;
        }
    }
}
