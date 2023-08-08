using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repository.Interface;

namespace FunBooksAndVideos.Repository
{
    public class ItemLineRepository : IItemLineRepository
    {
        public List<ItemLine> GetItemLinesByOrderId(int orderId)
        {
            // For the sake of example, let's return a mock list of ItemLines.
            return new List<ItemLine>
            {
                new ItemLine { ItemLineId = 1, OrderId = orderId, ProductId = 101, MembershipId = null },
                new ItemLine { ItemLineId = 2, OrderId = orderId, ProductId = 102, MembershipId = 1 },
                new ItemLine { ItemLineId = 3, OrderId = orderId, ProductId = 103, MembershipId = null },
            };
        }
    }
}
