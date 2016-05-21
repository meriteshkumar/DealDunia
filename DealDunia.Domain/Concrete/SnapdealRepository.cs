using DealDunia.Domain.Abstract;
using DealDunia.Infrastructure.Helpers;
using DealDunia.Infrastructure.Abstract;
using DealDunia.Service;
using System.Collections.Generic;
using System.Linq;

namespace DealDunia.Domain.Concrete
{
    public class SnapdealRepository : ILookupRepository
    {
        public List<IItemResponse> GetItem(Infrastructure.Helpers.ItemRequest request)
        {
            Snapdeal serviceRef = new Snapdeal();

            var response = serviceRef.ItemSearch(new ItemRequest
            {
                Keywords = request.Keywords,
            });

            XmlParser parser = new XmlParser();
            List<IItemResponse> itemResponse = new List<SnapdealItemResponse>().Cast<IItemResponse>().ToList();
            parser.MapXMLtoClass(response, itemResponse, "productInfoList", new SnapdealItemResponse());

            return itemResponse;
        }
    }
}