using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using DealDunia.Domain.Entities;

namespace DealDunia.Web.Controllers
{
    public class StoreController : Controller
    {
        IStoreRepository repository = null;
        public StoreController()
        {
            this.repository = new SQLStoreRepository();
        }

        public ActionResult Stores()
        {           
            var deals = repository.StoresByCategory(null);
            return View(deals);
        }

        



    }
}
