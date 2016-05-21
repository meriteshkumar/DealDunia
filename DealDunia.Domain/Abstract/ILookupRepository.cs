
using DealDunia.Infrastructure.Abstract;
using DealDunia.Infrastructure.Helpers;
using System.Collections.Generic;
namespace DealDunia.Domain.Abstract
{
    public interface ILookupRepository
    {
        List<IItemResponse> GetItem(ItemRequest request);
    }
}
