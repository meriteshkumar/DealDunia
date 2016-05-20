using DealDunia.Domain.Concrete;
using DealDunia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDunia.Web.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        [HttpPost]
        public ActionResult Tags(string searchtext)
        {
            AmazonRepository rep = new AmazonRepository();
            var response = rep.GetItem(new ItemRequest
              {
                  Keywords = searchtext,
                  Operation = "ItemSearch",
                  ResponseGroup = "Images,ItemAttributes,Offers",
                  SearchIndex = "Electronics"
              });

            ViewBag.SearchedItem = searchtext;

            return View(response);
        }
    }
}
