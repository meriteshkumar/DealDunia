using DealDunia.Infrastructure.Abstract;
using System.ComponentModel;

namespace DealDunia.Infrastructure.Helpers
{
    public class AmazonItemResponse : IItemResponse
    {
         [DevAttribute(DisplayName = "ASIN", XPath = "Item/ASIN")]
        public string ProductId { get; set; }

         [DevAttribute(DisplayName = "Title", XPath = "ItemAttributes/Title")]
        public string Title { get; set; }

         [DevAttribute(DisplayName = "URL", XPath = "MediumImage/URL")]
        public string ImageUrl { get; set; }

         [DevAttribute(DisplayName = "FormattedPrice", XPath = "Price/FormattedPrice")]
        public string Amount { get; set; }

         [DevAttribute(DisplayName = "DetailPageURL", XPath = "Item/DetailPageURL")]
        public string DetailPageURL { get; set; }
    }
}
