using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Models
{
    public class Membership
    {
        public MembershipType? MembershipType { get; set; }
        public bool IsActivated { get; set; } = false;
        public int MembershipId { get; internal set; }

        public Membership(MembershipType? membershipType)
        {
            MembershipType = membershipType;
        }

    }
}