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

        public PartialViewResult ShopByStore()
        {
            var repository = new StoreRepository();
            var stores = repository.SelectAll();
            return PartialView("ShopByStore", stores);
        }

        public PartialViewResult ShopByCategory()
        {
            var repository = new CategoryRepository();
            var categories = repository.SelectAll();
            return PartialView("ShopByCategory", categories);
        }

        public PartialViewResult ExclusiveDeals(ExecutiveDealValues param)
        {
            var repository = new ExclusiveDealRepository();
            var deals = repository.Get(param);
            return PartialView("ExclusiveDeals", deals);
        }

        public PartialViewResult DailyDeals(DailyDealsValues param)
        {
            var repository = new DailyDealRepository();
            var deals = repository.Get(param);
            return PartialView("DailyDeals", deals);
        }

        public PartialViewResult CouponView(CouponValues param)
        {
            var repository = new CouponRepository();
            var deals = repository.Get(param);
            return PartialView("CouponView", deals);
        }

        public PartialViewResult OfferURL(int SourceStoreId)
        {
            var repository = new CommonRepository();
            var deals = repository.GetOfferURL(SourceStoreId);
            return PartialView("OfferURL", deals);
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

            FlipkartRepository rep1 = new FlipkartRepository();
            response.AddRange(rep1.GetItem(new ItemRequest
            {
                Keywords = searchtext
            }));

            ViewBag.SearchedItem = searchtext;

            return PartialView(response);
        }

        public PartialViewResult LeftSideBar()
        {
            var repository = new CommonRepository();
            var coupons = repository.GetCouponStoreCategories();

            return PartialView(coupons);
        }
    }
}
