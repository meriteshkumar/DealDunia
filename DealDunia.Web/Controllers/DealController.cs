using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using DealDunia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDunia.Infrastructure.Utility;

namespace DealDunia.Web.Controllers
{
    public class DealController : Controller
    {
        public DealController()
        {
        }

        public ActionResult Daily()
        {
            IRepository<DailyDeals, DailyDealsValues> repository = new DailyDealRepository();
            var deals = repository.Get(new DailyDealsValues { StoreId = 0, StoreName = string.Empty });

            return View(deals);
        }

        public ActionResult Exclusive()
        {
            IRepository<ExecutiveDeals, ExecutiveDealValues> repository = new ExclusiveDealRepository();
            var deals = repository.Get(new ExecutiveDealValues { CategoryId = 0, CategoryName = string.Empty, StoreCategoryId = 0, StoreCategoryName = string.Empty, StoreId = 0, StoreName = string.Empty });

            return View(deals);
        }

        public ActionResult Coupon(string Offer, string Store, string Category)
        {
            IRepository<Coupon, CouponValues> repository = new CouponRepository();
            var coupons = repository.Get(new CouponValues { OfferType = Offer, OfferName = Store, StoreCategoryName = (Category==null?string.Empty:Utilities.DecodeUrl(Category)) });
            return View("Coupon", coupons);
        } 

       
    }
}
