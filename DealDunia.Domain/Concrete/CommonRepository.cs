﻿using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using DealDunia.Infrastructure.Utility;

namespace DealDunia.Domain.Concrete
{
    public class CommonRepository : ICommonRepository
    {

        public void UpdateCoupons(String Source, DataTable dt)
        {
            try
            {
                string procName = string.Empty;
                if (Source.ToLower() == "vcom")
                {
                    procName = "dbo.UpdateVCOMCoupons";
                }
                else if (Source.ToLower() == "payoom")
                {
                    procName = "dbo.UpdatePAYOOMCoupons";
                }
                else if (Source.ToLower() == "icw")
                {
                    procName = "dbo.UpdateICWCoupons";
                }

                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Coupons", dt);
                sqlParam[0].SqlDbType = SqlDbType.Structured;
                SqlHelper.ExecuteNonQuery(DbConfig.ConnectionString, CommandType.StoredProcedure, procName, sqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateStores(String Source, DataTable dt)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@Stores", dt);
                sqlParam[0].SqlDbType = SqlDbType.Structured;
                sqlParam[1] = new SqlParameter("@StoreSourceId", Source);
                sqlParam[1].SqlDbType = SqlDbType.VarChar;
                SqlHelper.ExecuteNonQuery(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.UpdateSourceStores", sqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OfferURL> GetOfferURL(int SourceStoreId)
        {
            //try
            //{
            List<OfferURL> OfferURLs = new List<OfferURL>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format("https://api.hasoffers.com/Apiv3/json?NetworkId=vcm&Target=Affiliate_OfferUrl&Method=findAll&api_key={0}&filters%5Boffer_id%5D={1}&filters%5Bstatus%5D=active&fields%5B%5D=id&fields%5B%5D=name&fields%5B%5D=offer_url", VCOM.APIKEY, SourceStoreId.ToString()));
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string json = reader.ReadToEnd();
                JObject data = JObject.Parse(json);
                JToken offer = null;
                OfferURL OfferURL = null;
                if (data["response"]["data"].ToString() != "[]")
                {
                    JObject offerURL = (JObject)data["response"]["data"];
                    foreach (var x in offerURL)
                    {
                        offer = x.Value;
                        if (offer["OfferUrl"]["name"].ToString().ToLower().Contains("sale") || offer["OfferUrl"]["name"].ToString().ToLower().Contains("%"))
                        {
                            OfferURL = new OfferURL();
                            OfferURL.id = Convert.ToInt16(offer["OfferUrl"]["id"].ToString());
                            OfferURL.name = offer["OfferUrl"]["name"].ToString();
                            OfferURL.offer_url = string.Format("http://tracking.vcommission.com/aff_c?offer_id={0}&aff_id={1}&url_id={2}", SourceStoreId, VCOM.AffiliateId, OfferURL.id);
                            OfferURLs.Add(OfferURL);
                        }
                    }
                }
            }
            return OfferURLs;
        }

        public IEnumerable<Category> Menus(string CategoryName)
        {
            List<Category> categories = new List<Category>();
            Category category = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetMenu", new SqlParameter[] {
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

        public IEnumerable<StoreCategory> GetCouponStoreCategories(string categoryName = null)
        {
            List<StoreCategory> categories = new List<StoreCategory>();
            StoreCategory category = null;
            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetCouponStoreCategories", new SqlParameter[] {
                    new SqlParameter("@CategoryName", string.IsNullOrEmpty(categoryName) ? null : categoryName)});

            while (reader.Read())
            {
                category = new StoreCategory();
                category.StoreCategoryId = (Int16)((IDataRecord)reader)["StoreCategoryId"];
                category.StoreCategoryName = ((IDataRecord)reader)["StoreCategoryName"].ToString();
                category.Image = ((IDataRecord)reader)["Image"].ToString();
                category.ParentId = (Int16)((IDataRecord)reader)["ParentId"];
                category.StoreSourceId = (Int16)((IDataRecord)reader)["StoreSourceId"];
                category.CampaignId = (Int32)((IDataRecord)reader)["CampaignId"];
                categories.Add(category);
            }
            return categories;
        }

        public string GetOutURL(string Source, string Id)
        {
            return SqlHelper.ExecuteScalar(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetOutUrl", new SqlParameter[]{
                new SqlParameter("@Source", Source), new SqlParameter("@Id", Id)
            }).ToString();
        }
    }
}
