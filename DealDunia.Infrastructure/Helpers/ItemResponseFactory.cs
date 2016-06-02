using DealDunia.Infrastructure.Abstract;

namespace DealDunia.Infrastructure.Helpers
{
    public class ItemResponseFactory
    {
        public static IItemResponse CreateItemReponse(string responseType)
        {
            IItemResponse response = null;

            if (responseType.ToUpper().Equals("AMAZONITEMRESPONSE"))
                response = new AmazonItemResponse();
            else if (responseType.ToUpper().Equals("FLIPKARTITEMRESPONSE"))
                response = new FlipkartItemResponse();

            return response;
        }
    }
}
