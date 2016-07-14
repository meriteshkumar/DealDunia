using DealDunia.Infrastructure.Abstract;
using System.ComponentModel;


namespace DealDunia.Infrastructure.Helpers
{
    public class FlipkartItemResponse : IItemResponse
    {
        [DevAttribute(DisplayName = "productId", XPath = "productBaseInfoV1/productId")]
        public string ProductId { get; set; }

       [DevAttribute(DisplayName = "title", XPath = "productBaseInfoV1/title")]
        public string Title { get; set; }

         [DevAttribute(DisplayName = "value", XPath = "entry/value", PreviousNode = "key", PreviousNodeValue = "400x400")]
        public string ImageUrl { get; set; }

         [DevAttribute(DisplayName = "amount", XPath = "maximumRetailPrice/amount")]
        public string Amount { get; set; }

          [DevAttribute(DisplayName = "productUrl", XPath = "productBaseInfoV1/productUrl")]
        public string DetailPageURL { get; set; }
    }

    public class FlipkartDODT
    {
        [DevAttribute(DisplayName = "title", XPath = "dotdList/title")]
        public string Title { get; set; }

        [DevAttribute(DisplayName = "url", XPath = "dotdList/description")]
        public string Description { get; set; }

        [DevAttribute(DisplayName = "url", XPath = "dotdList/imageUrls/url", PreviousNode = "resolutionType", PreviousNodeValue = "default")]
        public string ImageUrl { get; set; }

        [DevAttribute(DisplayName = "title", XPath = "dotdList/url")]
        public string DetailPageURL { get; set; }
    }
}
