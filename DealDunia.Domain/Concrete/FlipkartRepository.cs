using DealDunia.Domain.Abstract;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Infrastructure.Abstract;
using DealDunia.Service;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using DealDunia.Domain.Entities;

namespace DealDunia.Domain.Concrete
{
    public class FlipkartRepository : ILookupRepository
    {
        public string StoreName { get { return "Flipkart"; } }
        public string StoreImage { get { return "Stores/Flipkart/Flipkart.jpg"; } }
        
        public List<IItemResponse> GetItem(Infrastructure.Helpers.ItemRequest request)
        {
            Flipkart serviceRef = new Flipkart();

            var response = serviceRef.ItemSearch(new ItemRequest
            {
                Keywords = request.Keywords,
            });

            XmlParser parser = new XmlParser();
            List<IItemResponse> itemResponse = new List<FlipkartItemResponse>().Cast<IItemResponse>().ToList();
            parser.MapXMLtoClass(response, itemResponse, "productInfoList", "FlipkartItemResponse");

            return itemResponse;
        }

        public List<DOTD> GetDODT()
        {
            List<DOTD> listDODT = new List<DOTD>();
            Flipkart serviceRef = new Flipkart();
            string json = serviceRef.DOTD();            
            JObject data = JObject.Parse(json);            
            foreach (var x in data)
            {
                JToken offer = x.Value;
                for (int i = 0; i < offer.Count(); i++)
                {
                    DOTD dodt = new DOTD();
                    dodt.StoreName = StoreName;
                    dodt.StoreImage = StoreImage;
                    dodt.Title = offer[i]["title"].ToString();
                    dodt.Description = offer[i]["description"].ToString();
                    dodt.DetailPageURL = offer[i]["url"].ToString();
                    dodt.ImageUrl = offer[i]["imageUrls"][0]["url"].ToString();
                    listDODT.Add(dodt);
                }
                
            }
            return listDODT;
        }
    }
}
