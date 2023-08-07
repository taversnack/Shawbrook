namespace FunBooksAndVideos.Models
{
    public class Membership
    {
        public MembershipType? MembershipType { get; set; }
        public bool IsActivated { get; set; } = false;

        public Membership(MembershipType membershipType)
        {
            MembershipType = membershipType;
        }

    }
}