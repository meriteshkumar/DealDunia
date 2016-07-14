
using DealDunia.Infrastructure.Abstract;
using DealDunia.Infrastructure.Helpers;
using System.Collections.Generic;
using DealDunia.Domain.Entities;
namespace DealDunia.Domain.Abstract
{
    public interface ILookupRepository
    {
        string StoreName { get; }
        string StoreImage { get; }

        List<IItemResponse> GetItem(ItemRequest request);
        List<DOTD> GetDODT();
    }
}
