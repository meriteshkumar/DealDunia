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
    
    public partial class CouponCategoryMap
    {
        public int CouponCatMapId { get; set; }
        public long CouponId { get; set; }
        public short StoreCategoryId { get; set; }
    
        public virtual Coupon Coupon { get; set; }
        public virtual StoreCategory StoreCategory { get; set; }
    }
}
