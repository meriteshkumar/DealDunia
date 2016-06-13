using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using System.Web.Mvc;
using System.Linq;

namespace DealDunia.Web.Controllers
{
    public class NavController : Controller
    {
        IStoreRepository repository;

        public NavController()
        {
            this.repository = new SQLStoreRepository();
        }

        public PartialViewResult Menu()
        {
            var categories = repository.Menus.Distinct();
            return PartialView("Menu", categories);
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
    }
}
