using DealDunia.Domain.Abstract;
using DealDunia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DealDunia.Domain.Concrete
{
    public class CategoryRepository : IRepository<Category, CategoryValues>
    {
        public List<Category> SelectAll()
        {
            List<Category> categories = new List<Category>();
            Category category = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetCategories");

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

        public List<Category> Get(CategoryValues criteria)
        {
            List<Category> categories = new List<Category>();
            Category category = null;

            SqlDataReader reader = SqlHelper.ExecuteReader(DbConfig.ConnectionString, CommandType.StoredProcedure, "dbo.GetSubCategories", new SqlParameter[] { new SqlParameter("@CategoryId", criteria.CategoryId), new SqlParameter("@CategoryName", criteria.CategoryName) });

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

        public void Insert(Category obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Category obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(CategoryValues criteria)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
