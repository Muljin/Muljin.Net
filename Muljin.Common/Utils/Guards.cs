using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Utils
{
    public static class Guards
    {
        /// <summary>
        /// Ensure a string consists only of latin alpha characters (a-zA-Z)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void LatinOnly(string obj, string paramName = null, string message = null)
        {
            foreach(var o in obj){
                if((o >= 'a' && o <='z') || (o >= 'A' && o <= 'Z')){
                    continue;
                }
                
                throw new ArgumentException(message ?? "Invalid input. Input must consist of letters only", paramName);
            }
        }

        /// <summary>
        /// Ensure a string only consists of alpha numeric characters
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AlphaNumeric(string obj, string paramName = null, string message = null)
        {
            foreach(var o in obj)
            {
                if (!Char.IsLetterOrDigit(o))
                {
                    throw new ArgumentException(message ?? "Invalid input. Input must consist of alpha numeric characters only", paramName);
                }
            }
        }

        /// <summary>
        /// Check value is greater than limit
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        public static void GreaterThan(int value, int limit, string paramName = null, string message = null)
        {
            if(value <= limit)
            {
                throw new ArgumentException(message ?? $"Invalid paramter. Parameter must be greater than {limit}", paramName);
            }

        }

        /// <summary>
        /// Check value is greater than limit
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        public static void GreaterThan(decimal value, decimal limit, string paramName = null, string message = null)
        {
            if(value <= limit)
            {
                throw new ArgumentException(message ?? $"Invalid paramter. Parameter must be greater than {limit}", paramName);
            }

        }

        /// <summary>
        /// Validate an enum is defiend is not the default 0 (e.g. None) enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void EnumDefined<T>(T obj, string paramName = null, string message = null) where T : struct, Enum
        {
            if(!typeof(T).IsEnum){
                throw new Exception("Invalid type used");
            }

            if(!Enum.IsDefined<T>(obj))
            {
                throw new ArgumentException("Enum not defined", paramName);
            }

            if( ((IConvertible)obj).ToInt32(null) == 0){
                throw new ArgumentException("Enum cannot be default value", paramName);
            }
        }

        /// <summary>
        /// Validate a specified length for a string, ignoring whitespaces and trimming
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void Length(string input, int min = -1, int max = -1, bool allowWhiteSpace = false)
        {
            if(allowWhiteSpace)
            {
                ArgumentNullException.ThrowIfNull(input, nameof(input));
            }else{
                ArgumentNullException.ThrowIfNullOrWhiteSpace(input, nameof(input));
                input = input.Trim();
            }

            var len = input.Length;

            //check min length
            if(min > -1 && len < min)
            {
                throw new ArgumentException("Invalid input length.");
            }

            //check max length
            if(max >-1 && len > max){
                throw new ArgumentException("Invalid input length.");
            }
        }

        /// <summary>
        /// Check value is less than given limit
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        public static void LessThan(int value, int limit, string paramName = null, string message = null) 
        {
            if(value >= limit)
            {
                throw new ArgumentException(message ?? $"Invalid parameter. {paramName ?? string.Empty} must be less than {limit}", paramName);
            }
        }

        /// <summary>
        /// Check value is less than given limit
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        public static void LessThan(decimal value, decimal limit, string paramName = null, string message = null) 
        {
            if(value >= limit)
            {
                throw new ArgumentException(message ?? $"Invalid parameter. {paramName ?? string.Empty} must be less than {limit}", paramName);
            }
        }

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
        public static void NotDefault(string obj, string paramName = null, string message = null)
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

        /// <summary>
        /// Throws exception if two objects are equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void NotEqual<T>(T obj1, T obj2) where T : IEquatable<T>
        {
            if(obj1.Equals(obj2)){
                throw new ArgumentException("Values cannot be equal");
            }
        }

        public static void NotNull(object obj, string paramName = null, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName, message ?? "Parameter cannot be null");
            }
        }


        public static void NotNullOrDefault(object obj, string paramName = null, string message = null)
        {
            Guards.NotNull(obj, paramName, message);

            if (obj == default)
            {
                throw new ArgumentException(message ?? "Parameter cannot be default value", paramName);
            }
        }

        /// <summary>
        /// Check if string is null or whitespace, throw exception if either
        /// </summary>
        /// <param name="obj"></param>
        public static void NotNullOrDefault(string obj, string paramName = null, string message = null)
        {
            Guards.NotNull(obj, paramName, message);

            if (String.IsNullOrWhiteSpace(obj))
            {
                throw new ArgumentException(message ?? "Parameter cannot be empty", paramName);
            }
        }

        public static void NotNullOrDefault(Guid obj, string paramName = null, string message = null)
        {
            Guards.NotNull(obj, paramName, message);
            if(obj == default)
            {
                throw new ArgumentException(message ?? "Guid cannot be empty", paramName);
            }
        }
        
        /// <summary>
        /// Ensure a string only consists of numbers
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void Numeric(string obj, string paramName = null, string message = null)
        {
            foreach(var o in obj)
            {
                if (!Char.IsDigit(o))
                {
                    throw new ArgumentException(message ?? "Invalid input. Input must consist of numbers only", paramName);
                }
            }
        }
        
    }
}
