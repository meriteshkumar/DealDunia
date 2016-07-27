using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DealDunia.Domain.Concrete
{
    public class CouponRepository : IRepository<Coupon, CouponValues>
    {
        public System.Collections.Generic.List<Coupon> SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<Coupon> Get(CouponValues criteria)
        {
            List<Coupon> coupons = new List<Coupon>();
            Coupon coupon = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetCoupons", new SqlParameter[] { 
                new SqlParameter("@OfferType", string.IsNullOrEmpty(criteria.OfferType) ? null : criteria.OfferType)
                , new SqlParameter("@OfferName", string.IsNullOrEmpty(criteria.OfferName) ? null : criteria.OfferName)
                , new SqlParameter("@StoreCategoryName", string.IsNullOrEmpty(criteria.StoreCategoryName) ? null : criteria.StoreCategoryName)
            });

            while (reader.Read())
            {
                coupon = new Coupon();
                coupon.CouponId = Convert.ToInt64(((IDataRecord)reader)["CouponId"]);
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
                coupon.StoreCatMapId = Convert.ToInt32(((IDataRecord)reader)["StoreCatMapId"]);

                coupons.Add(coupon);
            }
            return coupons;
        }

        public void Insert(Coupon obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Coupon obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(CouponValues criteria)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
