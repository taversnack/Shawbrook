using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repository.Interface;

namespace FunBooksAndVideos.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        public Membership GetMembershipById(int membershipId)
        {

            // For the sake of example, let's return a mock Membership object.
            return new Membership
            {
                MembershipId = membershipId
            };
        }

        public MembershipStatus GetMembershipStatus(int customerId, int membershipId)
        {
            return new MembershipStatus()
            {
                CustomerId = customerId,
                MembershipId = membershipId,
                IsActive = false
            };
        }

        public void UpdateMembershipStatus(MembershipStatus membershipStatus)
        {

        }
    }
}
