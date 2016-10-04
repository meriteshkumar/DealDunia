using System;
using System.Web.Optimization;

namespace DealDunia.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                //"~/Content/menu1.css",
                //"~/Content/category.css",
                "~/Content/style.min.css",
                "~/Content/megamenu.min.css",
                "~/Content/carousel.min.css"
                ));

            //bundles.Add(new StyleBundle("~/Content/css/carousel").Include(
            //    "~/Content/carousel.css"
            //    ));

            //bundles.Add(new ScriptBundle("~/bundles/js")
            //    .Include(
            //    "~/Scripts/jquery-2.2.3.min.js",
            //    "~/Scripts/jquery-ui.min.js",
            //    "~/Scripts/jquery.validate.min.js",
            //    "~/Scripts/jquery.validate.unobtrusive.min.js",
            //    "~/Scripts/jquery.unobtrusive-ajax.min.js",
            //    "~/Scripts/bootstrap.min.js",
            //    "~/Scripts/jquery.flexisel.js"
            //    ));

            //bundles.Add(new ScriptBundle("~/bundles/js/slider")
            //    .Include(
            //        "~/Scripts/jquery.flexisel.js"
            //    ));
        }
    }
}