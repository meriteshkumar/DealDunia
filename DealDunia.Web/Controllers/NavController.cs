using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using System.Web.Mvc;
using System.Linq;
using DealDunia.Infrastructure.Abstract;
using DealDunia.Infrastructure.Helpers;
using System.Collections.Generic;
using DealDunia.Domain.Entities;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using DealDunia.Infrastructure.Utility;

namespace DealDunia.Web.Controllers
{
    public class NavController : Controller
    {
        public NavController()
        {
        }

        public PartialViewResult Menu(string position)
        {
            var repository = new CommonRepository();
            var categories = repository.Menus(null).Distinct();

            if (position.ToUpper() == "HEADER")
                return PartialView("Menu", categories);
            else
                return PartialView("Footer", categories);
        }

       

                    

        public PartialViewResult SearchResult(string searchtext)
        {
            List<IItemResponse> response = null;

            AmazonRepository rep = new AmazonRepository();
            response = rep.GetItem(new ItemRequest
            {
                Keywords = searchtext,
                Operation = "ItemSearch",
                ResponseGroup = "Images,ItemAttributes,Offers",
                SearchIndex = "All"
            });

            //FlipkartRepository rep1 = new FlipkartRepository();
            //response.AddRange(rep1.GetItem(new ItemRequest
            //{
            //    Keywords = searchtext
            //}));

            ViewBag.SearchedItem = searchtext;

            return PartialView(response);
        }

        public PartialViewResult LeftSideBar()
        {
            var repository = new CommonRepository();
            var categories = repository.GetCouponStoreCategories();

            return PartialView(categories);
        }
    }
}
