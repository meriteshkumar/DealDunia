using DealDunia.Domain.Abstract;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Service;
using System.Xml;

namespace DealDunia.Domain.Concrete
{
    public class AmazonRepository : ILookupRepository
    {

        public string GetItem(Infrastructure.Helpers.ItemRequest request)
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
            ItemResponse itemResponse = new ItemResponse();
            parser.MapXMLtoClass(response, itemResponse);

            return null;
        }
    }
}
