using Muljin.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class StringExtensions
    {
        public static string ToSlug(this string input)
        {
            return StringUtils.ConvertToSlug(input);
        }

        public static string ToSnackCase(this string input)
        {
            return StringUtils.ConvertToSnakeCase(input);
        }

        public static string ToTitleCase(this string input)
        {
            return StringUtils.ConvertToTitleCase(input);
        }
    }
}
