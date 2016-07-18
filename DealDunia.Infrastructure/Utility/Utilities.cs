using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Infrastructure.Utility
{
    public static class Utilities
    {
        public static string EncodeUrl(string param)
        {
            return param.Replace(' ', '_').Replace("&", "and");
        }
        public static string DecodeUrl(string param)
        {
            return param.Replace('_', ' ').Replace("and", "&");
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
      
    }

    public static class VCOM
    {
        public static string AffiliateId { get { return "46159"; } }
        public static string APIKEY { get { return "4cd38b37164ca7837819c4196b1ff81fae72073a15054c60ba6a50653d97ac6d"; } }
    }

    public static class PAYOOM
    {
        public static string AffiliateId { get { return "26672"; } }
        //public static string APIKEY { get { return "4cd38b37164ca7837819c4196b1ff81fae72073a15054c60ba6a50653d97ac6d"; } }
    }
}
