using DealDunia.Infrastructure.Abstract;
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

        [DisplayName("amount")]
        public string Amount { get; set; }

        [DisplayName("productUrl")]
        public string DetailPageURL { get; set; }
    }
}
