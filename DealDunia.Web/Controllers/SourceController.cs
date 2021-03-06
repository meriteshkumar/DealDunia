﻿using System;
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
using System.Linq;

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
        public void UpdateCoupons(string Source)
        {
            try
            {
                if (Source.ToLower() == "vcom")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("https://tools.vcommission.com/api/coupons.php?apikey={0}", VCOM.APIKEY));
                    request.UserAgent = "Mozilla/4.0";
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
                else if (Source.ToLower() == "payoom")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://payoom.in/deeplinking/coupons-json.php/?affid={0}", PAYOOM.AffiliateId));
                    List<PAYOOMCoupons> deserializedResult = null;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string json = reader.ReadToEnd();
                        deserializedResult = serializer.Deserialize<List<PAYOOMCoupons>>(json);
                        DataTable dt = new DataTable();
                        dt = Utilities.ToDataTable(deserializedResult);
                        repository.UpdateCoupons(Source, dt);
                    }
                }
                else if (Source.ToLower() == "icw")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://assets.icubeswire.com/dealscoupons/api/getcoupon.php?API_KEY={0}", ICW.APIKeyCoupon));
                    List<ICWCoupons> deserializedResult = null;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    WebResponse response = request.GetResponse();
                    DateTime Expirydate;
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string json = reader.ReadToEnd();
                        json = json.Replace("},]", "}]");
                        deserializedResult = serializer.Deserialize<List<ICWCoupons>>(json);
                        DataTable dt = new DataTable();
                        dt = Utilities.ToDataTable(deserializedResult);
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            if (DateTime.TryParse(dt.Rows[i]["Expiry_Date"].ToString(), out Expirydate))
                            {
                                if (Expirydate < DateTime.Now.Date)
                                {
                                    dt.Rows.RemoveAt(i);
                                }
                            }
                            else
                            {
                                dt.Rows.RemoveAt(i);
                            }
                        }
                        dt.AcceptChanges();
                        repository.UpdateCoupons(Source, dt);
                    }
                }

            }
            catch (Exception ex)
            {
                //string errorText = ex.Message;
                throw ex;
            }
        }
        public void UpdateStores(string Source)
        {
            try
            {
                string request = string.Empty;
                if (Source.ToLower() == "1")
                {
                    request = string.Format("https://api.hasoffers.com/Apiv3/json?NetworkId={0}&Target=Affiliate_Offer&Method=findMyApprovedOffers&api_key={1}&filters%5Bconversion_cap%5D=&sort%5Bexpiration_date%5D=asc&fields%5B%5D=id&fields%5B%5D=name&fields%5B%5D=expiration_date&fields%5B%5D=status", VCOM.NetworkId, VCOM.APIKEY);
                }
                else if (Source.ToLower() == "4")
                {
                    request = string.Format("https://api.hasoffers.com/Apiv3/json?NetworkId={0}&Target=Affiliate_Offer&Method=findMyApprovedOffers&api_key={1}&filters%5Bconversion_cap%5D=", ICW.NetworkId, ICW.APIKEY);
                }
                else
                {
                    return;
                }
                HttpWebRequest httpRequest = null;
                httpRequest = (HttpWebRequest)WebRequest.Create(request);
                httpRequest.UserAgent = "Mozilla/4.0";
                List<SourceStore> stores = new List<SourceStore>();
                WebResponse response = httpRequest.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string json = reader.ReadToEnd();
                    JObject data = JObject.Parse(json);
                    JObject Offers = (JObject)data["response"]["data"];
                    foreach (var x in Offers)
                    {
                        JToken offer = x.Value;
                        //if (offer["Offer"]["name"].ToString().ToLower().Contains(" india"))
                        //{
                        SourceStore store = new SourceStore();
                        store.id = Convert.ToInt16(offer["Offer"]["id"]);
                        store.name = offer["Offer"]["name"].ToString();
                        store.expiration_date = offer["Offer"]["expiration_date"].ToString();
                        stores.Add(store);
                        //}
                    }
                    DataTable dt = new DataTable();
                    dt = Utilities.ToDataTable(stores);
                    repository.UpdateStores(Source, dt);
                }
            }
            catch (Exception ex)
            {
                string errorText = ex.Message;
            }
        }

        public string getCampaignCode(string categoryName)
        {
            var category = repository.GetCouponStoreCategories(categoryName).Single();
            if (category != null)
            {
                if (category.CampaignId > 0)
                {
                    string request = string.Empty;
                    if (category.StoreSourceId == 1)
                    {
                        request = string.Format("https://api.hasoffers.com/Apiv3/json?NetworkId={0}&Target=Affiliate_AdManager&Method=getCampaignCode&api_key={1}&campaign_id={2}", VCOM.NetworkId, VCOM.APIKEY, category.CampaignId);
                    }
                    HttpWebRequest httpRequest = null;
                    httpRequest = (HttpWebRequest)WebRequest.Create(request);
                    List<SourceStore> stores = new List<SourceStore>();
                    WebResponse response = httpRequest.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string json = reader.ReadToEnd();
                        JObject data = JObject.Parse(json);
                        return ((JToken)((JObject)data["response"]["data"])["CampaignCode"]).ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
