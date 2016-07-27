
using System.Collections.Generic;
namespace DealDunia.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreURL { get; set; }
        public string StoreImage { get; set; }
        public string StoreCategoryName { get; set; }
        public int SourceStoreId { get; set; }
        public int StoreCatMapId { get; set; }        
    }

    public class StoreValues
    {
        public string StoreName { get; set; }
        public string StoreCategoryName { get; set; }
    }
}
