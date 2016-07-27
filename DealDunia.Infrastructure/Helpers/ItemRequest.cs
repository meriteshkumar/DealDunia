
namespace DealDunia.Infrastructure.Helpers
{
    public class ItemRequest
    {
        public string Operation { get; set; }
        public string SearchIndex { get; set; }
        public string ResponseGroup { get; set; }
        public string Keywords { get; set; }
        public int PageIndex { get; set; }
    }
}
