using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDunia.Web.Areas.Admin.Controllers
{
    public class StoresController : Controller
    {
        public ActionResult Index()
        {
            return View(GetStores());
        }

        private IEnumerable<StoreViewModel> GetStores(short storeSourceId = 0, string storeName = null, bool? featured = null, bool? status = null, bool? active = null)
        {
            EComEntities context = new EComEntities();

            var stores = context.Stores
                                   .GroupJoin(context.StoreSources,
                                   store => store.StoreSourceId,
                                   storesource => storesource.StoreSourceId,
                                   (i, g) => new
                                   {
                                       i = i,
                                       g = g
                                   }).SelectMany(
                                       temp => temp.g.DefaultIfEmpty(),
                                       (temp, storesource) =>
                                       new StoreViewModel
                                       {
                                           StoreId = temp.i.StoreId,
                                           StoreName = temp.i.StoreName,
                                           StoreImage = temp.i.StoreImage,
                                           SourceStoreId = temp.i.SourceStoreId,
                                           StoreSourceId = temp.i.StoreSourceId,
                                           StoreSourceName = storesource.StoreSourceName,
                                           IsFeatured = temp.i.IsFeatured,
                                           Active = temp.i.Active,
                                           Status = temp.i.Status,
                                           CreatedOn = temp.i.CreatedOn,
                                           ModifiedOn = temp.i.ModifiedOn
                                       }
                                   ).
                                   Where(e => (storeSourceId == 0 || e.StoreSourceId == storeSourceId)
                                               && (string.IsNullOrEmpty(storeName) || e.StoreName.ToLower().Contains(storeName.ToLower()))
                                               && (featured == null || e.IsFeatured == featured)
                                               && (status == null || e.Status == status)
                                               && (active == null || e.Active == active)
                                               ).OrderBy(o => o.StoreName).ToList();

            return stores;
        }

        public PartialViewResult StoreGrid(short storeSourceId = 0, string storeName = null, bool? featured = null, bool? status = null, bool? active = null)
        {
            return PartialView(GetStores(storeSourceId, storeName, featured, status, active));
        }

        public PartialViewResult SaveStore()
        {
            return PartialView(new Store());
        }

        public PartialViewResult EditStore(int storeId)
        {
            EComEntities context = new EComEntities();

            var store = context.Stores.Where(e => e.StoreId == storeId).First();

            return PartialView("SaveStore", store);
        }

        public PartialViewResult CategoryMapLine()
        {
            return PartialView(new DealDunia.Web.Areas.StoreCategoryMap());
        }

        [HttpPost]
        public ActionResult Save(DealDunia.Web.Areas.Store store, string StoreCategoryMapList)
        {
            if (ModelState.IsValid)
            {
                EComEntities context = new EComEntities();
                int RowAffected = 0;

                if (store.StoreId == 0)
                {
                    RowAffected = context.SaveStore(
                            "A",
                            store.StoreId,
                            store.StoreName,
                            store.StoreDescription,
                            store.StoreURL,
                            store.StoreImage,
                            store.Affiliate,
                            store.AffiliateId,
                            store.StoreSourceId,
                            store.SourceStoreId,
                            store.IsFeatured,
                            store.ExpirationDate,
                            store.Active,
                            store.Status,
                            StoreCategoryMapList
                         );

                    //TempData["Message"] = "Record saved";
                }
                else
                {

                    RowAffected = context.SaveStore(
                            "E",
                            store.StoreId,
                            store.StoreName,
                            store.StoreDescription,
                            store.StoreURL,
                            store.StoreImage,
                            store.Affiliate,
                            store.AffiliateId,
                            store.StoreSourceId,
                            store.SourceStoreId,
                            store.IsFeatured,
                            store.ExpirationDate,
                            store.Active,
                            store.Status,
                            StoreCategoryMapList
                         );

                    //TempData["Message"] = "Record Updated";
                }

                context.SaveChanges();
            }
            else
            {
                return PartialView("EditStore", store);
            }

            return null;
        }
    }

    [Authorize]
    public class StoreViewModel
    {
        public short StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }
        public int? SourceStoreId { get; set; }
        public int? StoreSourceId { get; set; }
        public string StoreSourceName { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
