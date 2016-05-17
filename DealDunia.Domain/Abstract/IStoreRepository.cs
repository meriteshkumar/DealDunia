using DealDunia.Domain.Entities;
using System.Collections.Generic;

namespace DealDunia.Domain.Abstract
{
   public interface IStoreRepository
    {
       IEnumerable<Store> Stores { get; }
       IEnumerable<Category> Categories { get; }
       IEnumerable<Category> SubCategories(int CategoryId);
    }
}
