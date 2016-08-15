using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Domain.Entities
{
    public class ICWCoupons
    {
        public string Coupon_ID { get; set; }
        public string Campaign_ID { get; set; }
        public string Campaign_Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Type_Value { get; set; }
        public string Tracking_URL { get; set; }
        public string Added_Date { get; set; }
        public string Expiry_Date { get; set; }
    }

    //public class ICWStore
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string expiration_date { get; set; }
    //}
}
