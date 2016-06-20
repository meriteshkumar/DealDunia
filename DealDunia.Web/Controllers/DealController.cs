using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDunia.Web.Controllers
{
    public class DealController : Controller
    {
        IStoreRepository repository;

        public DealController()
        {
            this.repository = new SQLStoreRepository();
        }

        public ActionResult Daily()
        {
            var deals = repository.DailyDeals(0);

            return View(deals);
        }

        public ActionResult Exclusive()
        {
            var deals = repository.ExecutiveDeals(0, 0);

            return View(deals);
        }

        public ActionResult Store(string store)
        {
            var selectedStore = repository.Stores.Where(s => s.StoreName.ToUpper() == store.ToUpper()).SingleOrDefault();

            selectedStore.ExclusiveDeals = repository.ExecutiveDeals(0, 0, selectedStore.StoreName).ToList();
            selectedStore.DailyDeals = repository.DailyDeals(0, selectedStore.StoreName).ToList();

            return View(selectedStore);
        }
    }
}
