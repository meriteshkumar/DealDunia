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
            //var level1 = RouteData.Values["id1"].ToString();

            //var categories = repository.SubCategory(int.Parse(level1));

            //return View("BrowseCategory", categories);

            return View("Index");
        }

        public ActionResult Browse2()
        {
            var level1 = RouteData.Values["id1"].ToString();
            var level2 = RouteData.Values["id2"].ToString();

            return View("Index");
        }

        public ActionResult Browse3()
        {
            var level1 = RouteData.Values["id1"].ToString();
            var level2 = RouteData.Values["id2"].ToString();
            var level3 = RouteData.Values["id3"].ToString();

            return View("Index");
        }

    }
}
