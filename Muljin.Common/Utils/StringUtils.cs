﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Utils
{
    public static class StringUtils
    {
        public static string ConvertToTitleCase(string input)
        {
            var sb = new StringBuilder();
            bool capNext = true;
            foreach (var i in input)
            {
                if (capNext && Char.IsLower(i))
                {
                    sb.Append((char)(i - 32));
                }
                else
                {
                    sb.Append(i);
                }

                //if its a space, next is cap aswell
                capNext = i == ' ';
            }

            return sb.ToString();
        }

        public static string ConvertToSlug(string input)
        {
            if (input == null)
            {
                return null;
            }

            if (String.IsNullOrWhiteSpace(input))
            {
                return string.Empty;

            }

            return input.ToLower().Replace(' ', '-');
        }

        public static string ConvertToSnakeCase(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            //dont add on first char
            var sb = new StringBuilder();
            sb.Append(char.ToLower(input[0]));
            for(int i=1, len=input.Length; i<len; i++)
            {
                if (Char.IsUpper(input[i]))
                {
                    sb.Append('_');
                    sb.Append(Char.ToLower(input[i]));
                }
                else
                {
                    sb.Append(input[i]);
                }
            }

            return sb.ToString();
        }

        public static string GenerateRandomString(int length, string prefix = null)
        {
            var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZ";

            var sb = new StringBuilder();
            var rnd = new Random();

            if (prefix != null)
            {
                sb.Append(prefix);
            }

            for (var i = 0; i < length; i++)
            {
                sb.Append(chars[rnd.Next(0, 35)]);
            }

            return sb.ToString();
        }

        public static string LimitString(string input, int maxLength)
        {
            if(maxLength == 0)
            {
                return string.Empty;
            }

            if (String.IsNullOrWhiteSpace(input) || input.Length < maxLength)
            {
                return input;
            }

            return input.Substring(0, maxLength);           
        }
    }
}
