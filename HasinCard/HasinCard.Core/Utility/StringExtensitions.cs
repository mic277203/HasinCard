using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Core
{
    public static class StringExtensitions
    {
        public static int ToInt(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return 0;
            }

            int result;

            if (int.TryParse(obj, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
