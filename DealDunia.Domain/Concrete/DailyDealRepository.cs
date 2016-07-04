using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DealDunia.Domain.Concrete
{
    public class DailyDealRepository : IRepository<DailyDeals, DailyDealsValues>
    {
        public List<DailyDeals> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<DailyDeals> Get(DailyDealsValues criteria)
        {
            List<DailyDeals> deals = new List<DailyDeals>();
            DailyDeals deal = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetDailyDeals",
                new SqlParameter[] { 
                    new SqlParameter("@StoreId", criteria.StoreId == 0 ? 0 : criteria.StoreId)
                ,   new SqlParameter("@StoreName", criteria.StoreName)});

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

        public void Insert(DailyDeals obj)
        {
            throw new NotImplementedException();
        }

        public void Update(DailyDeals obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(DailyDealsValues criteria)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
