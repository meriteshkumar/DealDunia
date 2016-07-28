using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Domain.Entities
{
    public class StoreCategory
    {
        public Int16 StoreCategoryId { get; set; }
        public string StoreCategoryName { get; set; }
        public string Image { get; set; }
        public Int16 ParentId { get; set; }
    }
}
