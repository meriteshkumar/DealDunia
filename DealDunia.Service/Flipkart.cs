using DealDunia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.IO;
using System.Text;

namespace DealDunia.Service
{
    public class Flipkart
    {
        private const string AFFILIATE_ID = "sandeepmi3";
        private const string AFFILIATE_TOKEN = "48e7442debe1404ab298977ddf6e0d65";
        //private const string API_URL = "https://affiliate-api.flipkart.net/affiliate/1.0/search.xml";
        string API_URL = string.Empty, requestUrl = string.Empty;
        WebRequest request = null;
        WebResponse response = null;

        public XmlDocument ItemSearch(ItemRequest requestParams)
        {
            try
            {
                API_URL = "https://affiliate-api.flipkart.net/affiliate/1.0/search.xml";                
                requestUrl = string.Format("{0}?query={1}&resultCount={2}", API_URL, requestParams.Keywords, "10");
                
                request = HttpWebRequest.Create(requestUrl);
                request.Headers.Add("Fk-Affiliate-Id", AFFILIATE_ID);
                request.Headers.Add("Fk-Affiliate-Token",AFFILIATE_TOKEN);
                response = request.GetResponse();             

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(response.GetResponseStream());
                return xDoc;

                //return response.GetResponseStream();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DOTD()
        {
            try
            {
                string json = string.Empty;
                API_URL = "https://affiliate-api.flipkart.net/affiliate/offers/v1/dotd/json";
                requestUrl = API_URL;
                
                WebRequest request = HttpWebRequest.Create(requestUrl);
                request.Headers.Add("Fk-Affiliate-Id", AFFILIATE_ID);
                request.Headers.Add("Fk-Affiliate-Token", AFFILIATE_TOKEN);
                
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    json = reader.ReadToEnd();
                }
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}