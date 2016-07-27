using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Domain.Entities
{
    public class Coupon
    {
        public Int64 CouponId { get; set; }        
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public string OfferType { get; set; }
        public string CouponTitle { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }        
        public string CouponCode { get; set; }        
        public string OfferURL { get; set; }
        public string CouponExpiry { get; set; }        
        public string StoreImage { get; set; }
        public string StoreURL { get; set; }
        public string Featured { get; set; }
        public string Exclusive { get; set; }
        public int StoreCatMapId { get; set; }
    }

    public class CouponValues
    {
        public string OfferType { get; set; } 
        public string OfferName { get; set; }
        public string StoreCategoryName { get; set; }
    }
}
