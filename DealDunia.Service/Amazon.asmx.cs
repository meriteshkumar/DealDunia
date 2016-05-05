using DealDunia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Services;
using System.Xml;

namespace DealDunia.Service
{
    /// <summary>
    /// Summary description for Amazon
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Amazon : System.Web.Services.WebService
    {
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAI5MQ3KTFHR6HFMUA";
        private const string MY_AWS_SECRET_KEY = "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";
        private const string DESTINATION = "webservices.amazon.in";
        private const string Service = "AWSECommerceService";
        private const string Version = "2011-08-01";
        private const string SubscriptionId = "AKIAI5MQ3KTFHR6HFMUA";
        private const string AssociateTag = "itdezo-21";

        [WebMethod]
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

                requestUrl = helper.Sign(r1);

                WebRequest request = HttpWebRequest.Create(requestUrl);
                WebResponse response = request.GetResponse();

                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());
                return doc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
