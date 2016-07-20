
namespace DealDunia.Infrastructure.Abstract
{
    public interface IItemResponse
    {
        string ProductId { get; set; }
        string Title { get; set; }
        string ImageUrl { get; set; }
        string MRP { get; set; }
        string FormattedMRP { get; set; }
        string Amount { get; set; }
        string FormattedAmount { get; set; }
        string DetailPageURL { get; set; }
        string StoreName { get; }
        string StoreImage { get; }
    }
}
