using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MobileShopping.Utility
{
    public static class StringExtension
    {
        public static string RemoveHtmlTag(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
