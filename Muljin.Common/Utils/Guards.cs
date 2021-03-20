using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Utils
{
    public static class Guards
    {
        /// <summary>
        /// Throws exception is default value but not if null.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void NotDefault(object obj, string paramName, string message = null)
        {
            if (obj == null)
            {
                return;
            }

            if (obj == default)
            {
                throw new ArgumentException(message ?? "Invalid parameter. Parameter cannot be default value", paramName);
            }

        }

        /// <summary>
        /// Throws exception if default value but not if null
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void NotDefault(string obj, string paramName, string message = null)
        {
            if (obj == null)
            {
                return;
            }

            if (obj.Trim() == string.Empty)
            {
                throw new ArgumentException(message ?? "Property cannot be empty", paramName);
            }
        }


        public static void NotNullOrDefault(object obj, string paramName, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName, message ?? "Parameter cannot be null");
            }

            if (obj == default)
            {
                throw new ArgumentException(message ?? "Parameter cannot be default value", paramName);
            }
        }

        /// <summary>
        /// Check if string is null or whitespace, throw exception if either
        /// </summary>
        /// <param name="obj"></param>
        public static void NotNullOrDefault(string obj, string paramName, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName, message ?? "Parameter cannot be null");
            }

            if (String.IsNullOrWhiteSpace(obj))
            {
                throw new ArgumentException(message ?? "Parameter cannot be empty", paramName);
            }
        }
    }
}
