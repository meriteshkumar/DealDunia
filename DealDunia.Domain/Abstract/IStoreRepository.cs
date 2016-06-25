﻿using DealDunia.Domain.Entities;
using System.Collections.Generic;

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
    }
}
