using DealDunia.Infrastructure.Abstract;
using System.ComponentModel;

namespace DealDunia.Infrastructure.Helpers
{
    public class AmazonItemResponse : IItemResponse
    {
        [DisplayName("ASIN")]
        public string ProductId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("URL")]
        public string ImageUrl { get; set; }

        [DisplayName("Amount")]
        public string Amount { get; set; }

        [DisplayName("DetailPageURL")]
        public string DetailPageURL { get; set; }
    }
}
