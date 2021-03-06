﻿using DealDunia.Domain.Abstract;
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

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public PartialViewResult Menu(string position)
        {
            var repository = new CommonRepository();
            //var categories = repository.Menus(null).Distinct();

            if (position.ToUpper() == "HEADER")
            {
                //return PartialView("Menu", categories);
                return PartialView("Menu", null);
            }
            else
            {
                //return PartialView("Footer", categories);
                return PartialView("Footer", null);
            }
        }

        public PartialViewResult SearchResult(string searchtext, int page)
        {
            List<IItemResponse> response = null;

            AmazonRepository rep = new AmazonRepository();
            response = rep.GetItem(new ItemRequest
            {
                Keywords = searchtext,
                Operation = "ItemSearch",
                ResponseGroup = "Images,ItemAttributes,Offers",
                SearchIndex = "All",
                PageIndex = page
            });

            FlipkartRepository rep1 = new FlipkartRepository();
            response.AddRange(rep1.GetItem(new ItemRequest
            {
                Keywords = searchtext
            }));

            ViewBag.SearchedItem = searchtext;
            ViewBag.Page = page;
            return PartialView(response);
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public PartialViewResult LeftSideBar()
        {
            var repository = new CommonRepository();            
            var categories = repository.GetCouponStoreCategories();            
            return PartialView(categories);
        }
    }
}
