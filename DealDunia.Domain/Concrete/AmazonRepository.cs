using DealDunia.Domain.Abstract;
using DealDunia.Infrastructure.Abstract;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Service;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using DealDunia.Domain.Entities;

namespace DealDunia.Domain.Concrete
{
    public class AmazonRepository : ILookupRepository
    {
        public string StoreName { get { return "Amazon"; } }
        public string StoreImage { get { return "Stores/Amazon/Amazon.jpg"; } }
        
        public List<IItemResponse> GetItem(Infrastructure.Helpers.ItemRequest request)
        {
            Amazon serviceRef = new Amazon();

            var response = serviceRef.ItemSearch(new ItemRequest
            {
                Keywords = request.Keywords,
                Operation = request.Operation,
                ResponseGroup = request.ResponseGroup,
                SearchIndex = request.SearchIndex,
                PageIndex = request.PageIndex
            });

            XmlParser parser = new XmlParser();
            List<IItemResponse> itemResponse = new List<AmazonItemResponse>().Cast<IItemResponse>().ToList(); ;
            parser.MapXMLtoClass(response, itemResponse, "Item", "AmazonItemResponse");

            return itemResponse;
        }

        public List<DOTD> GetDODT()
        {
            throw new System.NotImplementedException();
        }
    }
}
