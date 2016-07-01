using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Domain.Entities
{
    public class VCOMCoupon
    {
        public string featured { get; set; }
        public string exclusive { get; set; }
        public string promo_id { get; set; }
        public int offer_id { get; set; }
        public string offer_name { get; set; }
        public string coupon_title { get; set; }
        public string category { get; set; }
        public string coupon_description { get; set; }
        public string coupon_type { get; set; }
        public string coupon_code { get; set; }
        public string ref_id { get; set; }
        public string link { get; set; }
        public string coupon_expiry { get; set; }
        public string added { get; set; }
        public string preview_url { get; set; }
        public bool status { get; set; }
        public string store_link { get; set; }
    }

    public class VCOMStore
    {
        public int id { get; set; }
        public string name { get; set; }        
        public string expiration_date { get; set; }        
    }

    public class OfferURL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string offer_url { get; set; }
    }
    
}
