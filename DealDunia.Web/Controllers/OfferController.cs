using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using DealDunia.Domain.Entities;
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

        public void UpdateCoupons(string Source)
        {
            try
            {
                if (Source == "VCOM")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tools.vcommission.com/api/coupons.php?apikey=4cd38b37164ca7837819c4196b1ff81fae72073a15054c60ba6a50653d97ac6d");
                    List<VCommissionResponse> deserializedResult = null;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string json = reader.ReadToEnd();
                        deserializedResult = serializer.Deserialize<List<VCommissionResponse>>(json);
                        DataTable dt = new DataTable();
                        dt = Utilities.ToDataTable(deserializedResult);
                        repository.UpdateVCOMCoupons(Source, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorText = ex.Message;
            }
        }

        public ActionResult Coupon(string Offer, string Store, string Category)
        {
            var coupons = repository.GetCoupons(Offer, Store, Category);
            return View(coupons);
        }

    }
}
