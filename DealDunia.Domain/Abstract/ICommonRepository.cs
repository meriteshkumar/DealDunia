using DealDunia.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace DealDunia.Domain.Abstract
{
    public interface ICommonRepository
    {
       IEnumerable<Category> Menus(string CategoryName);
       void UpdateCoupons(string Source, DataTable dt);
       void UpdateStores(string Source, DataTable dt);
       IEnumerable<string> GetCouponStoreCategories();
       IEnumerable<OfferURL> GetOfferURL(int SourceStoreId);
    }
}
