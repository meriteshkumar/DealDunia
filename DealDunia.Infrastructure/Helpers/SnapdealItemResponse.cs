﻿using DealDunia.Infrastructure.Abstract;
using System.ComponentModel;

namespace DealDunia.Infrastructure.Helpers
{
    public class SnapdealItemResponse : IItemResponse
    {
        [DisplayName("productId")]
        public string ProductId { get; set; }

        [DisplayName("title")]
        public string Title { get; set; }

        [DisplayName("value")]
        public string ImageUrl { get; set; }

        [DisplayName("MRP")]
        public string MRP { get; set; }
        public string FormattedMRP { get; set; }

        [DisplayName("amount")]
        public string Amount { get; set; }
        public string FormattedAmount { get; set; }

        [DisplayName("productUrl")]
        public string DetailPageURL { get; set; }

        public string StoreName { get { return "Snapdeal"; } }
        public string StoreImage { get { return "Stores/Snapdeal/Snapdeal.png"; } }
    }
}
