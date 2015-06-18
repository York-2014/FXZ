using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x.util
{
    class S
    {
        public const string EMPTY = "";
        
        public static bool blank(string s)
        {
            return null == s || EMPTY.Equals(s);
        }

        public static int toInt(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch (Exception e)
            {
            }

            return -1;
        }

        public static long toLong(string s)
        {
            try
            {
                return long.Parse(s);
            }
            catch (Exception e)
            {
            }

            return -1;
        }
    }
}
