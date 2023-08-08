using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repository.Interface;

namespace FunBooksAndVideos.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        public Membership GetMembershipById(int membershipId)
        {
            return new Membership
            {
                MembershipId = membershipId
            };
        }

        public void UpdateMembershipStatus(MembershipStatus membershipStatus)
        {
            // Data access logic to update the membership data in the database.
        }
    }
}
