
namespace DealDunia.Infrastructure.Abstract
{
    public interface IItemResponse
    {
        string ProductId { get; set; }
        string Title { get; set; }
        string ImageUrl { get; set; }
        string Amount { get; set; }
        string DetailPageURL { get; set; }
    }
}
