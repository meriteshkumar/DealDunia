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
                                    .Join(context.StoreSources,
                                    store => store.StoreSourceId,
                                    storesource => storesource.StoreSourceId,
                                    (store, storesource) =>
                                        new StoreViewModel
                                        {
                                            StoreName = store.StoreName,
                                            StoreImage = store.StoreImage,
                                            SourceStoreId = store.SourceStoreId,
                                            StoreSourceId = store.StoreSourceId,
                                            StoreSourceName = storesource.StoreSourceName,
                                            IsFeatured = store.IsFeatured,
                                            Active = store.Active,
                                            Status = store.Status,
                                            CreatedOn = store.CreatedOn,
                                            ModifiedOn = store.ModifiedOn
                                        }
                                    ).
                                    Where(e => (storeSourceId == 0 || e.StoreSourceId == storeSourceId)
                                                && (string.IsNullOrEmpty(storeName) || e.StoreName.Contains(storeName))
                                                && (bool)(e.IsFeatured == (featured ?? e.IsFeatured))
                                                && (bool)(e.Status == (status ?? e.Status))
                                                && (bool)(e.Active == (active ?? e.Active))).ToList().OrderBy(o => o.StoreName);

            return stores;
        }

        public PartialViewResult StoreGrid(short storeSourceId = 0, string storeName = null, bool? featured = null, bool? status = null, bool? active = null)
        {
            return PartialView(GetStores(storeSourceId, storeName, featured, status, active));
        }
    }

    [Authorize]
    public class StoreViewModel
    {
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
