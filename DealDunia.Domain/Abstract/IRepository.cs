using System.Collections.Generic;

namespace DealDunia.Domain.Abstract
{
    public interface IRepository <T1, T2> where T1: class
    {
        List<T1> SelectAll();
        List<T1> Get(T2 criteria);
        void Insert(T1 obj);
        void Update(T1 obj);
        void Delete(T2 criteria);
        void Save();
    }
}
