using DealDunia.Domain.Abstract;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Infrastructure.Abstract;
using DealDunia.Service;
using System.Collections.Generic;
using System.Linq;
using DealDunia.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace DealDunia.Domain.Concrete
{
    public class SnapdealRepository : ILookupRepository
    {
        public string StoreName { get { return "Snapdeal"; } }
        public string StoreImage { get { return "Stores/Snapdeal/Snapdeal.jpg"; } }

        public List<IItemResponse> GetItem(Infrastructure.Helpers.ItemRequest request)
        {
            throw new System.NotImplementedException();
            //Snapdeal serviceRef = new Snapdeal();

            //var response = serviceRef.ItemSearch(new ItemRequest
            //{
            //    Keywords = request.Keywords,
            //});

            //XmlParser parser = new XmlParser();
            //List<IItemResponse> itemResponse = new List<SnapdealItemResponse>().Cast<IItemResponse>().ToList();
            //parser.MapXMLtoClass(response, itemResponse, "productInfoList", new SnapdealItemResponse());

            //return itemResponse;
        }

        public List<DOTD> GetDODT()
        {
            List<DOTD> listDODT = new List<DOTD>();
            Snapdeal serviceRef = new Snapdeal();
            string json = serviceRef.DOTD();
            JObject data = JObject.Parse(json);                 
            foreach (var x in data)
            {
                JToken offer = x.Value;

                if (x.Value.Count() > 0 && x.Value[0]["errorCode"]==null)
                {
                    for (int i = 0; i < offer.Count(); i++)
                    {
                        DOTD dodt = new DOTD();
                        dodt.StoreName = StoreName;
                        dodt.StoreImage = StoreImage;
                        dodt.Title = offer[i]["title"].ToString();
                        dodt.MRP = string.Concat("Rs.", offer[i]["mrp"].ToString());
                        dodt.EffPrice = string.Concat("Rs.", offer[i]["effectivePrice"].ToString());
                        dodt.DetailPageURL = offer[i]["link"].ToString();
                        dodt.ImageUrl = offer[i]["imageLink"].ToString();
                        listDODT.Add(dodt);
                    }
                }
            }
            return listDODT;
        }
    }
}