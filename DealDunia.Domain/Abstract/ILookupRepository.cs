
using DealDunia.Infrastructure.Helpers;
using System.Collections.Generic;
namespace DealDunia.Domain.Abstract
{
    public interface ILookupRepository
    {
        List<ItemResponse> GetItem(ItemRequest request);
    }
}
