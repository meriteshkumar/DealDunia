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
        
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Daily()
        {
            IRepository<DailyDeals, DailyDealsValues> repository = new DailyDealRepository();
            var deals = repository.Get(new DailyDealsValues { StoreId = 0, StoreName = string.Empty });
            return View(deals);
        }
       
        public PartialViewResult _DailyDeals(DailyDealsValues param)
        {
            var repository = new DailyDealRepository();
            var deals = repository.Get(param);
            return PartialView("_DailyDeals", deals);
        }

        public PartialViewResult _DOTD()
        {
            var FR = new FlipkartRepository();
            var deals = FR.GetDODT();
            var SR = new SnapdealRepository();
            deals.AddRange(SR.GetDODT());
            return PartialView("_DOTD", deals);
        }

         [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Exclusive()
        {
            IRepository<ExecutiveDeals, ExecutiveDealValues> repository = new ExclusiveDealRepository();
            var deals = repository.Get(new ExecutiveDealValues { CategoryId = 0, CategoryName = string.Empty, StoreCategoryId = 0, StoreCategoryName = string.Empty, StoreId = 0, StoreName = string.Empty });
            return View(deals);
        }

        public PartialViewResult _ExclusiveDeals(ExecutiveDealValues param)
        {
            var repository = new ExclusiveDealRepository();
            var deals = repository.Get(param);
            return PartialView("_ExclusiveDeals", deals);
        }

        public ActionResult Coupon(string Offer, string Store, string Category)
        {
            IRepository<Coupon, CouponValues> repository = new CouponRepository();
            var coupons = repository.Get(new CouponValues { OfferType = Offer, OfferName = Store, StoreCategoryName = (Category == null ? string.Empty : Utilities.DecodeUrl(Category)) });
            return View("Coupons", coupons);
        }

        public PartialViewResult _Coupons(CouponValues param)
        {
            var repository = new CouponRepository();
            param.StoreCategoryName = param.StoreCategoryName == null ? string.Empty : Utilities.DecodeUrl(param.StoreCategoryName);
            var coupons = repository.Get(param);
            return PartialView("_Coupons", coupons);
        }

        public PartialViewResult _OfferURL(int SourceStoreId)
        {
            var repository = new CommonRepository();
            var deals = repository.GetOfferURL(SourceStoreId);
            return PartialView("_OfferURL", deals);
        }


    }
}
