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
    
    public partial class StoreCategory
    {
        public StoreCategory()
        {
            this.ExcDeals = new HashSet<ExcDeal>();
            this.Coupons = new HashSet<Coupon>();
            this.StoreCategoryMaps = new HashSet<StoreCategoryMap>();
            this.CouponCategoryMaps = new HashSet<CouponCategoryMap>();
        }
    
        public short StoreCategoryId { get; set; }
        public string StoreCategoryName { get; set; }
        public string Image { get; set; }
        public Nullable<short> ParentId { get; set; }
        public Nullable<short> DisplayOrder { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Logo { get; set; }
        public Nullable<short> StoreSourceId { get; set; }
        public Nullable<int> CampaignId { get; set; }
    
        public virtual ICollection<ExcDeal> ExcDeals { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual ICollection<StoreCategoryMap> StoreCategoryMaps { get; set; }
        public virtual ICollection<CouponCategoryMap> CouponCategoryMaps { get; set; }
        public virtual StoreSource StoreSource { get; set; }
    }
}
