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
            var categories = repository.Categories.Select(x => x.CategoryName).Distinct();
            return PartialView("Menu", categories);
        }

        public PartialViewResult ShopByStore()
        {
            var stores = repository.Stores;
            return PartialView("ShopByStore", stores);
        }

    }
}
