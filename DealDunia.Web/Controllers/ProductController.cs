using DealDunia.Domain.Concrete;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDunia.Web.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost]
        public ActionResult Search(string searchtext)
        {
            ViewBag.SearchedItem = searchtext;
            return View();
        }
    }
}
