using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using DealDunia.Domain.Entities;
using DealDunia.Infrastructure.Utility;

namespace DealDunia.Web.Controllers
{
    public class StoreController : Controller
    {
        IRepository<Store, string> repository = null;
        public StoreController()
        {
            this.repository = new StoreRepository();
        }    

        public ActionResult Stores()
        {
            var deals = repository.Get(null);
            return View(deals);
        }
        

    }
}
