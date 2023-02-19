using Muljin.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Limit a string to a maximum number of characters or less if string is shorter
        /// </summary>
        /// <param name="input"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Limit(this string input, int maxLength)
        {
            return StringUtils.LimitString(input, maxLength);
        }

        public static string ToSlug(this string input)
        {
            return StringUtils.ConvertToSlug(input);
        }

        public static string ToSnakeCase(this string input)
        {
            return StringUtils.ConvertToSnakeCase(input);
        }

        public static string ToTitleCase(this string input)
        {
            return StringUtils.ConvertToTitleCase(input);
        }
    }
}
