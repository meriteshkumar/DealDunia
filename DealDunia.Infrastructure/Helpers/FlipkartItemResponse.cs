using DealDunia.Infrastructure.Abstract;
using System.ComponentModel;
using System;


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
        public string MRP { get; set; }
        public string FormattedMRP { get { return (decimal.ToInt32(Convert.ToDecimal(MRP)) == 0 ? string.Empty : string.Format("{0:0,0}", decimal.ToInt32(Convert.ToDecimal(MRP)))); } set { ; } }

        [DevAttribute(DisplayName = "amount", XPath = "flipkartSpecialPrice/amount")]
        public string Amount { get; set; }
        public string FormattedAmount { get { return (decimal.ToInt32(Convert.ToDecimal(Amount)) == 0 ? string.Empty : string.Format("{0:0,0}", decimal.ToInt32(Convert.ToDecimal(Amount)))); } set { ; } }

        [DevAttribute(DisplayName = "productUrl", XPath = "productBaseInfoV1/productUrl")]
        public string DetailPageURL { get; set; }

        public string StoreName { get { return "Flipkart"; } }
        public string StoreImage { get { return "Stores/Flipkart/Flipkart.jpg"; } }
    }
}
