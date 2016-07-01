using System.Web.Mvc;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using DealDunia.Infrastructure.Utility;

namespace DealDunia.Web.Controllers
{
    public class OfferController : Controller
    {
        IStoreRepository repository = null;

        public OfferController()
        {
            this.repository = new SQLStoreRepository();
        }

        

        public ActionResult Coupon(string Offer, string Store, string Category)
        {
            var coupons = repository.GetCoupons(Offer, Store, Utilities.DecodeUrl(Category));
            return View(coupons);
        }      

    }
}
