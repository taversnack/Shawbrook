using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
    }
}
