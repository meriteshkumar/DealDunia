
using System.Data;


namespace DealDunia.Repository
{
    public class SQLRepository
    {
        public IDataReader GetCategories()
        {
            return SqlHelper.ExecuteReader("Data Source=IRIS-CSG-554;Initial Catalog=Ecom;Integrated Security=True", CommandType.StoredProcedure, "dbo.GetCategories");

        }
    }
}
