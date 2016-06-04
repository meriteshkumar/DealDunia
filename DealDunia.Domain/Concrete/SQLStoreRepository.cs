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

                SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=.;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetStores");

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

        public IEnumerable<Category> Menus
        {
            get
            {
                List<Category> categories = new List<Category>();
                Category category = null;

                SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=.;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetMenu");

                while (reader.Read())
                {
                    category = new Category();
                    category.CategoryId = (int)((IDataRecord)reader)["CategoryId"];
                    category.CategoryName = ((IDataRecord)reader)["CategoryName"].ToString();
                    category.Image = ((IDataRecord)reader)["Image"].ToString();
                    category.RootId = (int)((IDataRecord)reader)["RootId"];
                    category.ParentId = (int)((IDataRecord)reader)["ParentId"];
                    category.Level = Convert.ToInt16(((IDataRecord)reader)["Level"]);
                    categories.Add(category);
                }
                return categories;
            }
        }

        public IEnumerable<Category> TopCategory
        {
            get
            {
                List<Category> categories = new List<Category>();
                Category category = null;

                SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=.;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetCategories");

                while (reader.Read())
                {
                    category = new Category();
                    category.CategoryId = (int)((IDataRecord)reader)["CategoryId"];
                    category.CategoryName = ((IDataRecord)reader)["CategoryName"].ToString();
                    category.Image = ((IDataRecord)reader)["Image"].ToString();
                    category.RootId = -1;
                    category.ParentId = -1;
                    category.Level = -1;
                    categories.Add(category);
                }
                return categories;
            }
        }

        public IEnumerable<Category> SubCategory(int CategoryId, string CategoryName)
        {
            List<Category> categories = new List<Category>();
            Category category = null;

            SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=.;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetSubCategories", new SqlParameter[] { new SqlParameter("@CategoryId", CategoryId), new SqlParameter("@CategoryName", CategoryName) });

            while (reader.Read())
            {
                category = new Category();
                category.CategoryId = (int)((IDataRecord)reader)["CategoryId"];
                category.CategoryName = ((IDataRecord)reader)["CategoryName"].ToString();
                category.Image = ((IDataRecord)reader)["Image"].ToString();
                category.RootId = 0;
                category.ParentId = (int)((IDataRecord)reader)["ParentId"];
                category.Level = Convert.ToInt16(((IDataRecord)reader)["Level"]);
                categories.Add(category);
            }
            return categories;
        }

        public IEnumerable<ExecutiveDeals> ExecutiveDeals(int StoreId, int CategoryId)
        {
            List<ExecutiveDeals> deals = new List<ExecutiveDeals>();
            ExecutiveDeals deal = null;

            SqlDataReader reader = SqlHelper.ExecuteReader("Data Source=.;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetExcDeals", new SqlParameter[] { new SqlParameter("@StoreId", StoreId), new SqlParameter("@CategoryId", CategoryId) });

            while (reader.Read())
            {
                deal = new ExecutiveDeals();
                deal.ExcDealId = (int)((IDataRecord)reader)["ExcDealId"];
                deal.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                deal.CategoryId = (int)((IDataRecord)reader)["CategoryId"];
                deal.Title = ((IDataRecord)reader)["Title"].ToString();
                deal.Description = ((IDataRecord)reader)["Description"].ToString();
                deal.Image = ((IDataRecord)reader)["Image"].ToString();
                deal.URL = ((IDataRecord)reader)["URL"].ToString();
                deals.Add(deal);
            }
            return deals;
        }
    }
}
