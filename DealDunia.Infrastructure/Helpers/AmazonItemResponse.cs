using DealDunia.Infrastructure.Abstract;
using System.ComponentModel;
using System;

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

        [DevAttribute(DisplayName = "Amount", XPath = "ListPrice/Amount")]
        public string MRP { get; set; }
        public string FormattedMRP { get { return (Convert.ToInt32(MRP) == 0 ? string.Empty : string.Format("{0:0,0}", Convert.ToInt32(MRP)/100)); } set { ; } }

        [DevAttribute(DisplayName = "Amount", XPath = "LowestNewPrice/Amount")]
        public string Amount { get; set; }
        public string FormattedAmount { get { return (Convert.ToInt32(Amount) == 0 ? string.Empty : string.Format("{0:0,0}", Convert.ToInt32(Amount)/100)); } set { ; } }

        [DevAttribute(DisplayName = "DetailPageURL", XPath = "Item/DetailPageURL")]
        public string DetailPageURL { get; set; }

        public string StoreName { get { return "Amazon"; } }
        public string StoreImage { get { return "Stores/Amazon/Amazon.jpg"; } }
    }
}
