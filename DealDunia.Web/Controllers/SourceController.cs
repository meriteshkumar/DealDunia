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
using Newtonsoft.Json.Linq;

namespace DealDunia.Web.Controllers
{
    public class SourceController : Controller
    {
        //
        // GET: /VCOM/
        ICommonRepository repository = null;

        public SourceController()
        {
            this.repository = new CommonRepository();
        }

        #region VCOM
        public void UpdateCoupons(string Source)
        {
            try
            {
                if (Source.ToLower() == "vcom")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tools.vcommission.com/api/coupons.php?apikey=4cd38b37164ca7837819c4196b1ff81fae72073a15054c60ba6a50653d97ac6d");
                    List<VCOMCoupon> deserializedResult = null;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string json = reader.ReadToEnd();
                        deserializedResult = serializer.Deserialize<List<VCOMCoupon>>(json);
                        DataTable dt = new DataTable();
                        dt = Utilities.ToDataTable(deserializedResult);
                        repository.UpdateCoupons(Source, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorText = ex.Message;
            }
        }
        public void UpdateStores(string Source)
        {
            try
            {
                if (Source.ToLower() == "vcom")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hasoffers.com/Apiv3/json?NetworkId=vcm&Target=Affiliate_Offer&Method=findMyApprovedOffers&api_key=4cd38b37164ca7837819c4196b1ff81fae72073a15054c60ba6a50653d97ac6d&filters%5Bconversion_cap%5D=&sort%5Bexpiration_date%5D=asc&fields%5B%5D=id&fields%5B%5D=name&fields%5B%5D=expiration_date&fields%5B%5D=status");
                    List<VCOMStore> stores = new List<VCOMStore>();
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string json = reader.ReadToEnd();
                        JObject data = JObject.Parse(json);
                        JObject Offers = (JObject)data["response"]["data"];
                        foreach (var x in Offers)
                        {
                            JToken offer = x.Value;
                            if (offer["Offer"]["name"].ToString().ToLower().Contains(" india"))
                            {
                                VCOMStore store = new VCOMStore();
                                store.id = Convert.ToInt16(offer["Offer"]["id"]);
                                store.name = offer["Offer"]["name"].ToString();                                
                                store.expiration_date = offer["Offer"]["expiration_date"].ToString();
                                stores.Add(store);
                            }
                        }
                        DataTable dt = new DataTable();
                        dt = Utilities.ToDataTable(stores);
                        repository.UpdateStores(Source, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorText = ex.Message;
            }
        }
        
        #endregion

    }
}
