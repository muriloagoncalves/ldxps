
using System;
using System.Linq;

namespace LDXPS.Common.Extensions
{
    public static class HelperExtensions
    {
        public static decimal ApenasNumeros(this string value)
        {
            return Convert.ToDecimal(new string(value.Where(char.IsDigit).ToArray()));
        }
    }
}
