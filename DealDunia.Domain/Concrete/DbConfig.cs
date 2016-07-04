
namespace DealDunia.Domain.Concrete
{
    public class DbConfig
    {
        public static string ConnectionString {
            get {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["connectionString"].ToString();
            }
        }
    }
}
