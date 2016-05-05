using DealDunia.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Domain.Concrete
{
    public class AmazonRepository : ILookupRepository
    {

        public string GetItem(Infrastructure.Helpers.ItemRequest request)
        {
            DealDuniaServiceReference.AmazonSoapClient serviceRef = new DealDuniaServiceReference.AmazonSoapClient();

            var response = serviceRef.ItemSearch(new DealDuniaServiceReference.ItemRequest
            {
                Keywords = request.Keywords,
                Operation = request.Operation,
                ResponseGroup = request.ResponseGroup,
                SearchIndex = request.SearchIndex
            });

            return null;
        }
    }
}
