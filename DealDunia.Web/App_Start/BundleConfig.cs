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
                "~/Content/category.css",
                "~/Content/menu.css",
                "~/Content/sidebar-menu.css",
                "~/Content/style.css"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/js")
            //    .Include(
            //    //"~/Scripts/jquery-{version}.js",
            //    //"~/Scripts/jquery-ui.min.js",
            //    //"~/Scripts/jquery.validate.min.js",
            //    //"~/Scripts/jquery.validate.unobtrusive.min.js",
            //    //"~/Scripts/jquery.unobtrusive-ajax.min.js",
            //    "~/Scripts/jquery-2.2.3.min.js",
            //    "~/Scripts/bootstrap.min.js"));   
        }
    }
}