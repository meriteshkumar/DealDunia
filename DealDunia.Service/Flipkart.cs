using DealDunia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace DealDunia.Service
{
    public class Flipkart
    {
        private const string AFFILIATE_ID = "sandeepmi3";
        private const string AFFILIATE_TOKEN = "48e7442debe1404ab298977ddf6e0d65";
        //private const string API_URL = "https://affiliate-api.flipkart.net/affiliate/1.0/search.xml";

        public XmlDocument ItemSearch(ItemRequest requestParams)
        {
            try
            {
                string API_URL = "https://affiliate-api.flipkart.net/affiliate/1.0/search.xml";
                String requestUrl = string.Format("{0}?query={1}&resultCount={2}", API_URL, requestParams.Keywords, "50");

                WebRequest request = HttpWebRequest.Create(requestUrl);
                request.Headers.Add("Fk-Affiliate-Id", AFFILIATE_ID);
                request.Headers.Add("Fk-Affiliate-Token",AFFILIATE_TOKEN);

                WebResponse response = request.GetResponse();

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
    }
}