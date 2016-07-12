using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DealDunia.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "Out",
               url: "out/{source}/{id}",
               defaults: new { controller = "Out", action = "Out" }
           );

            routes.MapRoute(
                name: "CouponsByStore",
                url: "Coupons/Store/{Store}",
                defaults: new { controller = "Deal", action = "Coupon" }
            );

            routes.MapRoute(
                name: "CouponsByCategory",
                url: "Coupons/{Category}",
                defaults: new { controller = "Deal", action = "Coupon" }
            );

            //routes.MapRoute(
            //    name: "UpdateCoupons",
            //    url: "VCOM/UpdateCoupons/{Source}",
            //    defaults: new { controller = "Offer", action = "UpdateCoupons" }
            //);            

            routes.MapRoute(
                name: "StoresByCategory",
                url: "stores",
                defaults: new { controller = "Store", action = "Stores" }
            );

            routes.MapRoute(
                name: "Store",
                url: "store/{store}",
                defaults: new { controller = "Store", action = "Store" }
            );

            routes.MapRoute(
                name: "Exclusive",
                url: "exclusive-deals",
                defaults: new { controller = "Deal", action = "Exclusive" }
            );

            routes.MapRoute(
                name: "Deals",
                url: "daily-deals",
                defaults: new { controller = "Deal", action = "Daily" }
                );

            routes.MapRoute(
                name: "Level3",
                url: "category/{id1}/{id2}/{id3}",
                defaults: new { controller = "Category", action = "Browse3" }
            );

            routes.MapRoute(
                name: "Level2",
                url: "category/{id1}/{id2}",
                defaults: new { controller = "Category", action = "Browse2" }
            );

            routes.MapRoute(
                name: "Level1",
                url: "category/{id1}",
                defaults: new { controller = "Category", action = "Browse1" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}