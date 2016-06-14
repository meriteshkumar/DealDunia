using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using System.Web.Mvc;
using System.Linq;
using DealDunia.Infrastructure.Abstract;
using DealDunia.Infrastructure.Helpers;
using System.Collections.Generic;

namespace DealDunia.Web.Controllers
{
    public class NavController : Controller
    {
        IStoreRepository repository;

        public NavController()
        {
            this.repository = new SQLStoreRepository();
        }

        public PartialViewResult Menu(string position)
        {
            var categories = repository.Menus.Distinct();

            if (position.ToUpper() == "HEADER")
                return PartialView("Menu", categories);
            else
                return PartialView("Footer", categories);
        }

        public PartialViewResult ShopByStore()
        {
            var stores = repository.Stores;
            return PartialView("ShopByStore", stores);
        }

        public PartialViewResult ShopByCategory()
        {
            var categories = repository.TopCategory;
            return PartialView("ShopByCategory", categories);
        }

        public PartialViewResult ExclusiveDeals()
        {
            var deals = repository.ExecutiveDeals(0, 0);
            return PartialView("ExclusiveDeals", deals);
        }

        public PartialViewResult DailyDeals()
        {
            var deals = repository.DailyDeals(0);
            return PartialView("DailyDeals", deals);
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
    }
}
