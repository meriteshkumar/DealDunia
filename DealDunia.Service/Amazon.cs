using DealDunia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace DealDunia.Service
{
    public class Amazon
    {
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAI5MQ3KTFHR6HFMUA";
        private const string MY_AWS_SECRET_KEY = "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";
        private const string DESTINATION = "webservices.amazon.in";
        private const string Service = "AWSECommerceService";
        private const string Version = "2011-08-01";
        private const string SubscriptionId = "AKIAI5MQ3KTFHR6HFMUA";
        private const string AssociateTag = "gmed-21";

        //public System.IO.Stream ItemSearch(ItemRequest requestParams)
        public XmlDocument ItemSearch(ItemRequest requestParams)
        {
            try
            {
                String requestUrl;

                SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);

                IDictionary<string, string> r1 = new Dictionary<string, String>();
                r1["Service"] = Service;
                r1["Version"] = Version;
                r1["SubscriptionId"] = SubscriptionId;
                r1["AssociateTag"] = AssociateTag;
                r1["Operation"] = requestParams.Operation;                
                r1["SearchIndex"] = requestParams.SearchIndex;
                r1["ResponseGroup"] = requestParams.ResponseGroup;
                r1["Keywords"] = requestParams.Keywords;                
                r1["ItemPage"] = requestParams.PageIndex.ToString();

                requestUrl = helper.Sign(r1);

                WebRequest request = HttpWebRequest.Create(requestUrl);
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