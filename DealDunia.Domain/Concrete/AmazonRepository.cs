using DealDunia.Domain.Abstract;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Service;
using System.Collections.Generic;
using System.Xml;

namespace DealDunia.Domain.Concrete
{
    public class AmazonRepository : ILookupRepository
    {

        public List<ItemResponse> GetItem(Infrastructure.Helpers.ItemRequest request)
        {
            Amazon serviceRef = new Amazon();

            var response = serviceRef.ItemSearch(new ItemRequest
            {
                Keywords = request.Keywords,
                Operation = request.Operation,
                ResponseGroup = request.ResponseGroup,
                SearchIndex = request.SearchIndex
            });

            XmlParser parser = new XmlParser();
            List<ItemResponse> itemResponse = new List<ItemResponse>();
            parser.MapXMLtoClass(response, itemResponse, "Item");

            return itemResponse;
        }
    }
}
