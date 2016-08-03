using DealDunia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Text;

namespace DealDunia.Service
{
    public class Snapdeal
    {
        private const string AFFILIATE_ID = "73767";
        private const string AFFILIATE_TOKEN = "e1c33ba925c45276d76a1c7bffacbc";
        //private const string API_URL = "affiliate-feeds.snapdeal.com/feed/api";
        string API_URL = string.Empty;
        public System.IO.Stream ItemSearch(ItemRequest requestParams)
        {
            try
            {                
                String requestUrl = string.Format("{0}?query={1}&resultCount={2}", API_URL, requestParams.Keywords, "10");

                WebRequest request = HttpWebRequest.Create(requestUrl);
                request.Headers.Add("Snapdeal-Affiliate-Id", AFFILIATE_ID);
                request.Headers.Add("Snapdeal-Token-Id", string.Concat(AFFILIATE_TOKEN, " ", API_URL));

                WebResponse response = request.GetResponse();

                return response.GetResponseStream();
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
                string API_URL = "http://affiliate-feeds.snapdeal.com/feed/api/dod/offer";
                String requestUrl = API_URL;
                WebRequest request = HttpWebRequest.Create(requestUrl);
                request.Headers.Add("Snapdeal-Affiliate-Id", AFFILIATE_ID);
                request.Headers.Add("Snapdeal-Token-Id", AFFILIATE_TOKEN);
                //request.Headers.Add("Accept", "application/xml");
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