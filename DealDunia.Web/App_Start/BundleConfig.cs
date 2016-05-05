using System;
using System.Web.Optimization;

namespace DealDunia.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Conent/css").Include("~/Content/*.css"));
        }
    }
}