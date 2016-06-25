using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDunia.Domain.Concrete;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Domain.Abstract;

namespace DealDunia.Web.Controllers
{
    public class CategoryController : Controller
    {
        IStoreRepository repository = new SQLStoreRepository();

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

            var categories = repository.SubCategory(0, level1 + "/" + level2);

            return View("BrowseCategory", categories);
        }

        public ActionResult Browse3()
        {
            var level1 = RouteData.Values["id1"].ToString();
            var level2 = RouteData.Values["id2"].ToString();
            var level3 = RouteData.Values["id3"].ToString();

            level1 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level1);
            level2 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level2);
            level3 = DealDunia.Infrastructure.Utility.Utilities.DecodeUrl(level3);

            return View("Index");
        }

    }
}
