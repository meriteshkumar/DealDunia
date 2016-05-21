using DealDunia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DealDunia.Service
{
    public class Snapdeal
    {
        private const string AFFILIATE_ID = "sandeepmi3";
        private const string AFFILIATE_TOKEN = "48e7442debe1404ab298977ddf6e0d65";
        private const string API_URL = "affiliate-feeds.snapdeal.com/feed/api";

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
    }
}