using DealDunia.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace DealDunia.Domain.Abstract
{
   public interface IStoreRepository
    {
       IEnumerable<Store> Stores { get; }
       IEnumerable<Category> Menus(string CategoryName);
       IEnumerable<Category> TopCategory { get; }
       IEnumerable<Category> SubCategory(int CategoryId, string CategoryName);
       IEnumerable<ExecutiveDeals> ExecutiveDeals(int StoreId, int CategoryId, string StoreName = null, string CategoryName = null);
       IEnumerable<DailyDeals> DailyDeals(int StoreId, string StoreName = null);
       IEnumerable<Store> StoresByCategory(string StoreCategoryName);
       IEnumerable<Coupon> GetCoupons(string OfferType, string OfferName, string StoreCategoryName);
       void UpdateCoupons(string Source, DataTable dt);
       void UpdateStores(string Source, DataTable dt);
       IEnumerable<string> GetCouponStoreCategories();
       IEnumerable<OfferURL> GetOfferURL(int SourceStoreId);
    }
}
