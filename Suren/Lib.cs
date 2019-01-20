using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suren
{
    public class Lib
    {
        public static string ToStr(object v)
        {
            if (v == null) return string.Empty;
            return v.ToString();
        }
        public static int ToInt(object v)
        {
            if (v == null) return 0;
            if (v is int) return (int)v;
            int dv = 0;
            if (int.TryParse(ToStr(v), out dv))
            { }
            return dv;
        }
        public static decimal ToDecimal(object v)
        {
            if (v == null) return decimal.Zero;
            if (v is decimal) return (decimal)v;
            decimal dv = decimal.Zero;
            if (decimal.TryParse(ToStr(v), out dv))
            { }
            return dv;
        }

        public static bool ToBool(object v)
        {
            if (v == null) return false;
            if (v is bool) return (bool)v;
            return RLib.Utils.Converter.ObjToBool(v);
        }
    }
}
