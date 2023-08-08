using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Repository.Interface
{
    public interface IItemLineRepository
    {
        List<ItemLine> GetItemLinesByOrderId(int orderId);
    }
}
