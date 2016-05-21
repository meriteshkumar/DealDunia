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
        //
        // GET: /Product/

        [HttpPost]
        public ActionResult Tags(string searchtext)
        {
            List<IItemResponse> response = null;

            AmazonRepository rep = new AmazonRepository();
            response = rep.GetItem(new ItemRequest
              {
                  Keywords = searchtext,
                  Operation = "ItemSearch",
                  ResponseGroup = "Images,ItemAttributes,Offers",
                  SearchIndex = "Electronics"
              });

            FlipkartRepository rep1 = new FlipkartRepository();
            response.AddRange(rep1.GetItem(new ItemRequest
            {
                Keywords = searchtext
            }));

            ViewBag.SearchedItem = searchtext;

            return View(response);
        }
    }
}
