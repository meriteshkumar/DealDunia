using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Domain.Entities
{
    public class PAYOOMCoupons
    {
        public string campaign { get; set; }
        public string title { get; set; }
        public string coupon { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string link { get; set; }       
    }
}
