using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Infrastructure.Utility
{
    public class Utilities
    {
        public static string EncodeUrl(string param)
        {
            return param.Replace(' ', '-').Replace("&", "and");
        }
        public static string DecodeUrl(string param)
        {
            return param.Replace('-', ' ').Replace("and", "&");
        }
    }
}
