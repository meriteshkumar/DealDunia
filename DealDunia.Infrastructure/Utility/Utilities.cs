using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DealDunia.Infrastructure.Utility
{
    public static class Utilities
    {
        public static string EncodeUrl(string param)
        {
            //return param.Replace(' ', '_').Replace("&", "and");
            //return param.Replace(' ', '-').Replace("&", "and");
            return param.Replace(" & ", "-and-").Replace(" ", "-");
        }
        public static string DecodeUrl(string param)
        {
            //return param.Replace('_', ' ').Replace("and", "&");
            //return param.Replace('-', ' ').Replace("and", "&");
            return param.Replace("-and-", " & ").Replace('-', ' ');
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
        public static string NetworkId { get { return "vcm"; } }
    }

    public static class PAYOOM
    {
        public static string AffiliateId { get { return "26672"; } }        
    }

    public static class ICW
    {
        public static string AffiliateId { get { return "15688"; } }
        public static string APIKEY { get { return "408891a31c0cf3311e0c8d90241619cc5d3ca755cbb040e977eecf16202c4479"; } }
        public static string APIKeyCoupon { get { return "68e4593563e1b425a7717504bca103d6"; } }
        public static string NetworkId { get { return "icubes"; } }
    }
}
