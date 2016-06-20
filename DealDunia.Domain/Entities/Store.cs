
using System.Collections.Generic;
namespace DealDunia.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }
        public bool Affiliate { get; set; }
        public string AffiliateId { get; set; }

        public List<ExecutiveDeals> ExclusiveDeals { get;  set; }
        public List<DailyDeals> DailyDeals { get;  set; }
    }
}
