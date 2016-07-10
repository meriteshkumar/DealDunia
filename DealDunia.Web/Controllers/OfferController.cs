using System.Web.Mvc;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using DealDunia.Domain.Entities;
using DealDunia.Infrastructure.Utility;

namespace DealDunia.Web.Controllers
{
    public class OfferController : Controller
    {
        IRepository<Coupon,CouponValues> repository = null;

        public OfferController()
        {
            this.repository = new CouponRepository();
        }

        //public PartialViewResult Coupon(string Offer, string Store, string Category)
        //{
        //    var coupons = repository.Get(new CouponValues { OfferType = Offer, OfferName = Store, StoreCategoryName = Utilities.DecodeUrl(Category) });
        //    return PartialView("_CouponView", coupons);
        //}      

    }
}
