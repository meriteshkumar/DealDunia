using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDunia.Domain.Concrete;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;

namespace DealDunia.Web.Controllers
{
    public class CategoryController : Controller
    {
        ICommonRepository repository = new CommonRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse1()
        {
            var level1 = RouteData.Values["id1"].ToString();

            level1 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level1);

            ViewBag.ShowBrowse = 1;

            var categories = repository.Menus(level1);

            return View("BrowseCategory", categories);
        }

        public ActionResult Browse2()
        {
            var level1 = RouteData.Values["id1"].ToString();
            var level2 = RouteData.Values["id2"].ToString();

            level1 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level1);
            level2 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level2);

            ViewBag.ShowBrowse = 2;

            IRepository<Category, CategoryValues> repo = new CategoryRepository();

            var categories = repo.Get(new CategoryValues { CategoryId = 0, CategoryName = level1 + "/" + level2 });

            return View("BrowseCategory", categories);
        }

        public ActionResult Browse3(int page = 1)
        {
            var level1 = RouteData.Values["id1"].ToString();
            var level2 = RouteData.Values["id2"].ToString();
            var level3 = RouteData.Values["id3"].ToString();
            var Search = string.Empty;

            level1 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level1);
            level2 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level2);
            level3 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level3);

            if (level1 == "Men" || level1 == "Women")
                Search = level3 + " for " + level1;
            else if (level1.Contains("Baby"))
                Search = level3 + " for Baby " + level2;
            else
                Search = level3 + " in " + level2;


            ViewBag.SearchedItem = Search;
            ViewBag.Page = page;

            return View("Search");
        }

        public PartialViewResult _ShopByCategory()
        {
            var repository = new CategoryRepository();
            var categories = repository.SelectAll();
            return PartialView("_ShopByCategory", categories);
        }  
    }
}
