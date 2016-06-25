using DealDunia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DealDunia.Web.Controllers
{
    public class OfferController : Controller
    {
        public ActionResult Coupon()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tools.vcommission.com/api/coupons.php?apikey=4cd38b37164ca7837819c4196b1ff81fae72073a15054c60ba6a50653d97ac6d");

            List<VCommissionResponse> deserializedResult = null;

            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();


                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string json = reader.ReadToEnd();

                    deserializedResult = serializer.Deserialize<List<VCommissionResponse>>(json);
                }
            }
            catch (Exception ex)
            {
                string errorText = ex.Message;
            }

            return View(deserializedResult);
        }

    }
}
