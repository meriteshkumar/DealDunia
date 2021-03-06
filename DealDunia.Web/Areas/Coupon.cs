//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DealDunia.Web.Areas
{
    using System;
    using System.Collections.Generic;
    
    public partial class Coupon
    {
        public Coupon()
        {
            this.CouponCategoryMaps = new HashSet<CouponCategoryMap>();
        }
    
        public long CouponId { get; set; }
        public short StoreSourceId { get; set; }
        public string PromoId { get; set; }
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public string OfferType { get; set; }
        public string CouponTitle { get; set; }
        public string Category { get; set; }
        public Nullable<short> StoreCategoryId { get; set; }
        public string Description { get; set; }
        public string CouponCode { get; set; }
        public string OfferURL { get; set; }
        public string CouponStart { get; set; }
        public string CouponExpiry { get; set; }
        public Nullable<bool> Featured { get; set; }
        public Nullable<bool> Exclusive { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> OfferZone { get; set; }
        public Nullable<bool> Sale { get; set; }
    
        public virtual StoreCategory StoreCategory { get; set; }
        public virtual StoreSource StoreSource { get; set; }
        public virtual ICollection<CouponCategoryMap> CouponCategoryMaps { get; set; }
    }
}
