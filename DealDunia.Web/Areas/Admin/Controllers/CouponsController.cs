using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDunia.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CouponsController : Controller
    {
        public ActionResult Index()
        {
            EComEntities context = new EComEntities();

            var coupons = context.Coupons.Where(e => (bool)e.Status).ToList();

            return View(coupons);
        }

        public PartialViewResult _CouponGrid(int storeSourceId = 0, int storeCategoryId = 0, bool? featured = null, bool? status = null, string offerType = null, string store = null)
        {
            EComEntities context = new EComEntities();
            //IQueryable query = context.Coupons.Where(e => (storeSourceId == 0 || e.StoreSourceId == storeSourceId)
            //                                        && (storeCategoryId == 0 || e.StoreCategoryId == storeCategoryId)
            //                                        && (bool)(e.Featured == (featured ?? e.Featured))
            //                                        && (bool)(e.Status == (status ?? e.Status))
            //                                        && (e.OfferType == (string.IsNullOrEmpty(offerType) ? e.OfferType : offerType))
            //                                        && (e.OfferName.Contains((string.IsNullOrEmpty(store) ? e.OfferName : store))));
            //var sql = ((System.Data.Objects.ObjectQuery)query).ToTraceString();

            var coupons = context.Coupons.Where(e => (storeSourceId == 0 || e.StoreSourceId == storeSourceId)
                                                    && (storeCategoryId == 0 || e.StoreCategoryId == storeCategoryId)
                                                    //&& (bool)(e.Featured == (featured ?? e.Featured))
                                                    && (bool)(e.Status == (status ?? e.Status))
                                                    && (e.OfferType == (string.IsNullOrEmpty(offerType) ? e.OfferType : offerType))
                                                    && (e.OfferName.Contains((string.IsNullOrEmpty(store) ? e.OfferName : store)))).ToList();

            return PartialView(coupons);
        }

        public PartialViewResult _StoreSourceDropDown(string controlName)
        {
            EComEntities context = new EComEntities();

            var storeSource = context.StoreSources.OrderBy(d => d.StoreSourceName).ToList();

            return PartialView(storeSource);
        }

        public PartialViewResult _StoreDropDown(string controlName)
        {
            EComEntities context = new EComEntities();

            var store = context.Stores.Join(context.Coupons,
                s => new { StoreSourceId = (int?)s.StoreSourceId, SourceStoreId = (int?)s.SourceStoreId },
                c => new { StoreSourceId = (int?)c.StoreSourceId, SourceStoreId = (int?)c.OfferId },
                (s, c) => new StoreDropDown { StoreName = s.StoreName }).Distinct().ToList();

            return PartialView(store);
        }

        public ActionResult EditCoupon(int couponId, short storeCateogoryId)
        {
            EComEntities context = new EComEntities();

            var coupon = context.Coupons.Single(s => s.CouponId == couponId);
            coupon.StoreCategoryId = storeCateogoryId;
            context.SaveChanges();

            TempData["Message"] = "Record Updated";

            return RedirectToAction("Index");
        }

        public static string GetStoreName(short StoreSourceId, int OfferId)
        {
            EComEntities context = new EComEntities();
            string storeName;

            var st = context.Stores.FirstOrDefault(s => s.StoreSourceId == StoreSourceId && s.SourceStoreId == OfferId);

            if (st != null)
                storeName = st.StoreName;
            else
                storeName = "N/A";

            return storeName;
        }
    }

    [Authorize]
    public class StoreDropDown
    {
        public string StoreName { get; set; }
    }
}
