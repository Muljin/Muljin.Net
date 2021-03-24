using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends all none null or whitespace strings to a string builder
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="seperator"></param>
        public static void AppendNoneEmpty(this StringBuilder builder, string seperator, params string[] args)
        {
            bool first = true;
            foreach(var a in args)
            {
                if (!String.IsNullOrWhiteSpace(a))
                {
                    //add seperator if not first
                    if (!first && !String.IsNullOrEmpty(seperator))
                    {
                        builder.Append(seperator);
                    }

                    builder.Append(a);
                    first = false;
                }
            }
        }
    }
}
