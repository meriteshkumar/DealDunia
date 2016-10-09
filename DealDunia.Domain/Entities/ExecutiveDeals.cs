
namespace DealDunia.Domain.Entities
{
    public class ExecutiveDeals
    {
        public int ExcDealId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }        
        public string URL { get; set; }

    }

    public class ExecutiveDealValues
    {
        public int StoreId { get; set; }
        public int CategoryId { get; set; }
        public string StoreName { get; set; }
        public string CategoryName { get; set; }
        public int StoreCategoryId { get; set; }
        public string StoreCategoryName { get; set; }
        public bool IsFeatured { get; set; }
    }
}
