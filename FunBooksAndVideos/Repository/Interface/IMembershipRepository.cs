using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Repository.Interface
{
    public interface IMembershipRepository
    {
        Membership GetMembershipById(int membershipId);
        void UpdateMembershipStatus(MembershipStatus membershipStatus);
    }
}
