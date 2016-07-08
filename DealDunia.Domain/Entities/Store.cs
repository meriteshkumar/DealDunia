
using System.Collections.Generic;
namespace DealDunia.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreURL { get; set; }
        public string StoreImage { get; set; }
        public string StoreCategoryName { get; set; }
        public int SourceStoreId { get; set; }
        //public bool Affiliate { get; set; }
        //public string AffiliateId { get; set; }

        //public List<DailyDeals> DailyDeals { get; set; }
        //public List<OfferURL> OfferURLs { get; set; }
        //public List<ExecutiveDeals> ExclusiveDeals { get; set; }
        //public List<Coupon> Coupons { get; set; }
    }

    public class StoreValues
    {
        public string StoreName { get; set; }
        public string StoreCategoryName { get; set; }
    }
}
