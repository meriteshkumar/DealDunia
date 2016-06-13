using DealDunia.Domain.Entities;
using System.Collections.Generic;

namespace DealDunia.Domain.Abstract
{
   public interface IStoreRepository
    {
       IEnumerable<Store> Stores { get; }
       IEnumerable<Category> Menus { get; }
       IEnumerable<Category> TopCategory { get; }
       IEnumerable<Category> SubCategory(int CategoryId, string CategoryName);
       IEnumerable<ExecutiveDeals> ExecutiveDeals(int StoreId, int CategoryId);
       IEnumerable<DailyDeals> DailyDeals(int StoreId);
    }
}
