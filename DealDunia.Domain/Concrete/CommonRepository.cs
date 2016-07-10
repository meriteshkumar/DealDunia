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

namespace DealDunia.Domain.Concrete
{
    public class CommonRepository : ICommonRepository
    {
        private const string VCOM_Aff_Id = "46159";

        public void UpdateCoupons(String Source, DataTable dt)
        {
            if (Source.ToLower() == "vcom")
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Coupons", dt);
                sqlParam[0].SqlDbType = SqlDbType.Structured;
                SqlHelper.ExecuteNonQuery(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.UpdateVCOMCoupons", sqlParam);
            }
        }

        public void UpdateStores(String Source, DataTable dt)
        {
            if (Source.ToLower() == "vcom")
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Stores", dt);
                sqlParam[0].SqlDbType = SqlDbType.Structured;
                SqlHelper.ExecuteNonQuery(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.UpdateVCOMStores", sqlParam);
            }
        }

        public IEnumerable<OfferURL> GetOfferURL(int SourceStoreId)
        {
            //try
            //{
            List<OfferURL> OfferURLs = new List<OfferURL>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                string.Format("https://api.hasoffers.com/Apiv3/json?NetworkId=vcm&Target=Affiliate_OfferUrl&Method=findAll&api_key=4cd38b37164ca7837819c4196b1ff81fae72073a15054c60ba6a50653d97ac6d&filters%5Boffer_id%5D={0}&filters%5Bstatus%5D=active&fields%5B%5D=id&fields%5B%5D=name&fields%5B%5D=offer_url", SourceStoreId.ToString()));
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string json = reader.ReadToEnd();
                JObject data = JObject.Parse(json);
                if (data["response"]["data"].ToString() != "[]")
                {
                    JObject offerURL = (JObject)data["response"]["data"];
                    foreach (var x in offerURL)
                    {
                        JToken offer = x.Value;
                        //if (offer["Offer"]["name"].ToString().ToLower().Contains(" india"))
                        //{
                        OfferURL OfferURL = new OfferURL();
                        OfferURL.id = Convert.ToInt16(offer["OfferUrl"]["id"].ToString());
                        OfferURL.name = offer["OfferUrl"]["name"].ToString();
                        //OfferURL.offer_url = offer["OfferUrl"]["offer_url"].ToString().Replace("{affiliate_id}", "46159").Replace("{transaction_id}", OfferURL.id.ToString());
                        OfferURL.offer_url = string.Format("http://tracking.vcommission.com/aff_c?offer_id={0}&aff_id={1}&url_id={2}", SourceStoreId, VCOM_Aff_Id, OfferURL.id);
                        OfferURLs.Add(OfferURL);
                        //}
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

        public IEnumerable<string> GetCouponStoreCategories()
        {
            List<string> coupons = new List<string>();

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetCouponStoreCategories");

            while (reader.Read())
            {
                coupons.Add(reader.GetString(0));
            }
            return coupons;
        }


    }
}