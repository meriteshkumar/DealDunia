using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DealDunia.Domain.Concrete
{
    public class ExclusiveDealRepository : IRepository<ExecutiveDeals, ExecutiveDealValues>
    {
        public List<ExecutiveDeals> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<ExecutiveDeals> Get(ExecutiveDealValues criteria)
        {
            List<ExecutiveDeals> deals = new List<ExecutiveDeals>();
            ExecutiveDeals deal = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetExcDeals",
                        new SqlParameter[] { 
                            new SqlParameter("@StoreId", criteria.StoreId)
                        ,   new SqlParameter("@CategoryId", criteria.CategoryId) 
                        ,   new SqlParameter("@StoreName", criteria.StoreName)
                        ,   new SqlParameter("@CategoryName", criteria.CategoryName)
                        ,  new SqlParameter("@StoreCategoryId", criteria.StoreCategoryId)
                        ,   new SqlParameter("@StoreCategoryName", criteria.StoreCategoryName)
                        ,   new SqlParameter("@IsFeatured", criteria.IsFeatured)});

            while (reader.Read())
            {
                deal = new ExecutiveDeals();
                deal.ExcDealId = (int)((IDataRecord)reader)["ExcDealId"];
                deal.StoreId = Convert.ToInt16(((IDataRecord)reader)["StoreId"]);
                deal.StoreName = ((IDataRecord)reader)["StoreName"].ToString();
                deal.StoreImage = ((IDataRecord)reader)["StoreImage"].ToString();
                deal.CategoryId = (int)((IDataRecord)reader)["CategoryId"];
                deal.Title = ((IDataRecord)reader)["Title"].ToString();
                deal.Description = ((IDataRecord)reader)["Description"].ToString();
                deal.Image = ((IDataRecord)reader)["Image"].ToString();
                deal.URL = ((IDataRecord)reader)["URL"].ToString();
                deals.Add(deal);
            }
            return deals;
        }

        public void Insert(ExecutiveDeals obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ExecutiveDeals obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExecutiveDealValues criteria)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
