
using System.ComponentModel.DataAnnotations;
namespace DealDunia.Web.Areas
{
    [MetadataType(typeof(ExcDealMetaData))]
    public partial class ExcDeal
    {
    }

    public partial class ExcDealMetaData
    {
        [Required]
        public short StoreId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}