using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPayPay.lib
{
    public static class СhangeString
    {
        public static string MultiReplace( string str , char[] a , char b)
        {
            foreach (char char_c in a)
            {
                str = str.Replace(char_c, b);
            }
            return str;
        }
    }
}
