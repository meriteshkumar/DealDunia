﻿using DealDunia.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace DealDunia.Domain.Abstract
{
    public interface ICommonRepository
    {
       IEnumerable<Category> Menus(string CategoryName);
       void UpdateCoupons(string Source, DataTable dt);
       void UpdateStores(string Source, DataTable dt);
       IEnumerable<StoreCategory> GetCouponStoreCategories(string categoryName = null);
       IEnumerable<OfferURL> GetOfferURL(int SourceStoreId);
       string GetOutURL(string Source, string Id);
    }
}
