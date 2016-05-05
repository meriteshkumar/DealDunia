
using DealDunia.Infrastructure.Helpers;
namespace DealDunia.Domain.Abstract
{
    public interface ILookupRepository
    {
        string GetItem(ItemRequest request);
    }
}
