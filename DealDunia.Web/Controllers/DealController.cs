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

    }
}
