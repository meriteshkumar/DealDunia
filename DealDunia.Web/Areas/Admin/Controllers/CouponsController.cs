using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDunia.Web.Areas.Admin.Controllers
{
    public class CouponsController : Controller
    {
        //
        // GET: /Admin/Coupons/

        public ActionResult Index()
        {
            EComEntities context = new EComEntities();

            var coupons = context.Coupons.Where(e => (bool)e.Status).ToList();

            return View(coupons);
        }

        public PartialViewResult _CouponGrid(int storeSourceId = 0, int storeCategoryId = 0, bool? featured = null, bool? status = null)
        {
            EComEntities context = new EComEntities();

            var coupons = context.Coupons.Where(e => (storeSourceId == 0 || e.StoreSourceId == storeSourceId) && (storeCategoryId == 0 || e.StoreCategoryId == storeCategoryId) && (bool)(e.Featured == (featured ?? e.Featured)) && (bool)(e.Status == (status ?? e.Status))).ToList();

            return PartialView(coupons);
        }

        public PartialViewResult _StoreSourceDropDown(string controlName)
        {
            EComEntities context = new EComEntities();

            var storeSource = context.StoreSources.OrderBy(d => d.StoreSourceName).ToList();

            return PartialView(storeSource);
        }

        public ActionResult EditCoupon(int couponId, short storeCateogoryId)
        {
            EComEntities context = new EComEntities();

            var coupon = context.Coupons.Single(s => s.CouponId == couponId);
            coupon.StoreCategoryId =  storeCateogoryId;
            context.SaveChanges();

            TempData["Message"] = "Record Updated";

            return RedirectToAction("Index");
        }

    }
}
