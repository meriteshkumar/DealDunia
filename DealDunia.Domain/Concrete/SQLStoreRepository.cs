using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DealDunia.Domain.Concrete
{
    public class SQLStoreRepository : IStoreRepository
    {
        public IEnumerable<Store> Stores
        {
            get
            {
                List<Store> stores = new List<Store>();
                Store store = null;

                SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=IRIS-CSG-554;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetStores");

                while (reader.Read())
                {
                    store = new Store();
                    store.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                    store.StoreName = ((IDataRecord)reader)["StoreName"].ToString();
                    store.StoreImage = ((IDataRecord)reader)["StoreImage"].ToString();
                    store.Affiliate = (bool)((IDataRecord)reader)["Affiliate"];
                    store.AffiliateId = ((IDataRecord)reader)["AffiliateId"].ToString();
                    stores.Add(store);
                }
                return stores;
            }

        }

        public IEnumerable<Category> Categories
        {
            get
            {
                List<Category> categories = new List<Category>();
                Category category = null;

                SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=IRIS-CSG-554;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetCategories");

                while (reader.Read())
                {
                    category = new Category();
                    category.CategoryId = (int)((IDataRecord)reader)["CategoryId"];
                    category.CategoryName = ((IDataRecord)reader)["CategoryName"].ToString();
                    category.Image = ((IDataRecord)reader)["Image"].ToString();
                    categories.Add(category);
                }
                return categories;
            }
        }

        public IEnumerable<Category> SubCategories(int CateogyId)
        {

            List<Category> categories = new List<Category>();
            Category category = null;

            SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=IRIS-CSG-554;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetSubCategories", new SqlParameter[] { new SqlParameter("CategoryId", CateogyId) });

            while (reader.Read())
            {
                category = new Category();
                category.CategoryId = (int)((IDataRecord)reader)["CategoryId"];
                category.CategoryName = ((IDataRecord)reader)["CategoryName"].ToString();
                category.Image = ((IDataRecord)reader)["Image"].ToString();
                categories.Add(category);
            }
            return categories;
        }
    }
}
