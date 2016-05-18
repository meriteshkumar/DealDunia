using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDunia.Domain.Concrete;
using DealDunia.Infrastructure.Helpers;

namespace DealDunia.Web.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            //AmazonRepository rep = new AmazonRepository();
            //rep.GetItem(new ItemRequest
            //    {
            //        Keywords = "Harry Potter",
            //        Operation = "ItemSearch",
            //        ResponseGroup = "Images,ItemAttributes,Offers",
            //        SearchIndex = "Books"
            //    });

            return View();
        }

    }
}
