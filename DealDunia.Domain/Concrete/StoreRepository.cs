using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DealDunia.Domain.Concrete
{
    public class StoreRepository : IRepository<Store, StoreValues>
    {
        public List<Store> SelectAll()
        {
            List<Store> stores = new List<Store>();
            Store store = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetStores");

            while (reader.Read())
            {
                store = new Store();
                store.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                store.StoreName = ((IDataRecord)reader)["StoreName"].ToString();
                store.StoreImage = ((IDataRecord)reader)["StoreImage"].ToString();
                store.StoreURL = ((IDataRecord)reader)["StoreURL"].ToString();
                store.SourceStoreId = Convert.ToInt16(((IDataRecord)reader)["SourceStoreId"]);
                stores.Add(store);
            }
            return stores;
        }

        public List<Store> Get(StoreValues criteria)
        {
            List<Store> stores = new List<Store>();
            Store store = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetStoreByCategories", new SqlParameter[] { 
                new SqlParameter("@StoreCategoryName", string.IsNullOrEmpty(criteria.StoreCategoryName) ? null : criteria.StoreCategoryName)
                , new SqlParameter("@StoreName", string.IsNullOrEmpty(criteria.StoreName) ? null : criteria.StoreName)
            });

            while (reader.Read())
            {
                store = new Store();
                store.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                store.StoreName = ((IDataRecord)reader)["StoreName"].ToString();
                store.StoreURL = ((IDataRecord)reader)["StoreURL"].ToString();
                store.StoreImage = ((IDataRecord)reader)["StoreImage"].ToString();
                store.StoreCategoryName = ((IDataRecord)reader)["StoreCategoryName"].ToString();
                store.SourceStoreId = Convert.ToInt16(((IDataRecord)reader)["SourceStoreId"]);
                store.StoreCatMapId = Convert.ToInt32(((IDataRecord)reader)["StoreCatMapId"]);
                store.Alphabet = ((IDataRecord)reader)["Alphabet"].ToString();
                stores.Add(store);
            }
            return stores;
        }

        public void Insert(Store obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Store obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoreValues criteria)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
