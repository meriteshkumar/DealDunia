using System.Web.Mvc;
using System.Web.Optimization;

namespace DealDunia.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            BundleTable.Bundles.Add(new Bundle("~/Admin/bundles/js").Include("~/Areas/Admin/Scripts/admin.js"));
        }
    }
}
