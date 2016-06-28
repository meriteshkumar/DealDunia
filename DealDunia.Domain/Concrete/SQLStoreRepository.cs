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
        private const string _connectionString = "Data Source=.;Initial Catalog=Ecom;Integrated Security=True";

        public void UpdateVCOMCoupons(String Source, DataTable dt)
        {
            if (Source == "VCOM")
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Coupons", dt);
                sqlParam[0].SqlDbType = SqlDbType.Structured;
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "dbo.UpdateVCOMCoupons", sqlParam);
            }
        }

        public IEnumerable<Coupon> GetCoupons(string OfferType, string OfferName, string StoreCategoryName)
        {
            List<Coupon> coupons = new List<Coupon>();
            Coupon coupon = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetCoupons", new SqlParameter[] { 
                new SqlParameter("@OfferType", string.IsNullOrEmpty(OfferType) ? null : OfferType)
                , new SqlParameter("@OfferName", string.IsNullOrEmpty(OfferName) ? null : OfferName)
                , new SqlParameter("@StoreCategoryName", string.IsNullOrEmpty(StoreCategoryName) ? null : StoreCategoryName)
            });

            while (reader.Read())
            {
                coupon = new Coupon();
                //coupon.CouponId = Convert.ToInt16(((IDataRecord)reader)["CouponId"]);
                coupon.OfferId = Convert.ToInt16(((IDataRecord)reader)["OfferId"]);
                coupon.OfferName = ((IDataRecord)reader)["OfferName"].ToString();
                coupon.OfferType = ((IDataRecord)reader)["OfferType"].ToString();
                coupon.CouponTitle = ((IDataRecord)reader)["CouponTitle"].ToString();
                coupon.Category = ((IDataRecord)reader)["Category"].ToString();
                coupon.Description = ((IDataRecord)reader)["Description"].ToString();
                coupon.CouponCode = ((IDataRecord)reader)["CouponCode"].ToString();
                coupon.OfferURL = ((IDataRecord)reader)["OfferURL"].ToString();
                coupon.CouponExpiry = ((IDataRecord)reader)["CouponExpiry"].ToString();
                coupon.StoreImage = ((IDataRecord)reader)["StoreImage"].ToString();
                coupon.StoreURL = ((IDataRecord)reader)["StoreURL"].ToString();

                coupons.Add(coupon);
            }
            return coupons;
        }

        public IEnumerable<Store> StoresByCategory(string StoreCategoryName)
        {
            List<Store> stores = new List<Store>();
            Store store = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetStoreByCategories", new SqlParameter[] { 
                new SqlParameter("@StoreCategoryName", string.IsNullOrEmpty(StoreCategoryName) ? null : StoreCategoryName)});

            while (reader.Read())
            {
                store = new Store();
                store.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                store.StoreName = ((IDataRecord)reader)["StoreName"].ToString();
                store.StoreURL = ((IDataRecord)reader)["StoreURL"].ToString();
                store.StoreImage = ((IDataRecord)reader)["StoreImage"].ToString();
                store.StoreCategoryName = ((IDataRecord)reader)["StoreCategoryName"].ToString();
                //store.AffiliateId = ((IDataRecord)reader)["AffiliateId"].ToString();
                stores.Add(store);
            }
            return stores;
        }

        public IEnumerable<Store> Stores
        {
            get
            {
                List<Store> stores = new List<Store>();
                Store store = null;

                SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetStores");

                while (reader.Read())
                {
                    store = new Store();
                    store.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                    store.StoreName = ((IDataRecord)reader)["StoreName"].ToString();
                    store.StoreImage = ((IDataRecord)reader)["StoreImage"].ToString();
                    //store.Affiliate = (bool)((IDataRecord)reader)["Affiliate"];
                    //store.AffiliateId = ((IDataRecord)reader)["AffiliateId"].ToString();
                    stores.Add(store);
                }
                return stores;
            }

        }

        public IEnumerable<Category> Menus(string CategoryName)
        {
            List<Category> categories = new List<Category>();
            Category category = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetMenu", new SqlParameter[] { 
                    new SqlParameter("@CategoryName", string.IsNullOrEmpty(CategoryName) ? null : CategoryName)});

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

        public IEnumerable<Category> TopCategory
        {
            get
            {
                List<Category> categories = new List<Category>();
                Category category = null;

                SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetCategories");

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

        public IEnumerable<Category> SubCategory(int CategoryId, string CategoryName)
        {
            List<Category> categories = new List<Category>();
            Category category = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetSubCategories", new SqlParameter[] { new SqlParameter("@CategoryId", CategoryId), new SqlParameter("@CategoryName", CategoryName) });

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

        public IEnumerable<ExecutiveDeals> ExecutiveDeals(int StoreId, int CategoryId, string StoreName = null, string CategoryName = null)
        {
            List<ExecutiveDeals> deals = new List<ExecutiveDeals>();
            ExecutiveDeals deal = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetExcDeals",
                        new SqlParameter[] { 
                            new SqlParameter("@StoreId", StoreId)
                        ,   new SqlParameter("@CategoryId", CategoryId) 
                        ,   new SqlParameter("@StoreName", StoreName)
                        ,   new SqlParameter("@CategoryName", CategoryName)});

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

        public IEnumerable<DailyDeals> DailyDeals(int StoreId, string StoreName = null)
        {
            List<DailyDeals> deals = new List<DailyDeals>();
            DailyDeals deal = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetDailyDeals",
                new SqlParameter[] { 
                    new SqlParameter("@StoreId", StoreId == 0 ? 0 : StoreId)
                ,   new SqlParameter("@StoreName", StoreName)});

            while (reader.Read())
            {
                deal = new DailyDeals();
                deal.DailyDealId = Convert.ToInt16(((IDataRecord)reader)["DailyDealId"]);
                deal.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                deal.Title = ((IDataRecord)reader)["Title"].ToString();
                deal.Description = ((IDataRecord)reader)["Description"].ToString();
                deal.Image = ((IDataRecord)reader)["Image"].ToString();
                deal.URL = ((IDataRecord)reader)["URL"].ToString();
                deals.Add(deal);
            }
            return deals;
        }

        public IEnumerable<string> GetCouponStoreCategories()
        {
            List<string> coupons = new List<string>();

            SqlDataReader reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "dbo.GetCouponStoreCategories");

            while (reader.Read())
            {
                coupons.Add(reader.GetString(0));
            }
            return coupons;
        }
    }
}
