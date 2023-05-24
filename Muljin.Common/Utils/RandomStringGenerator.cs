using System;
using System.Text;

namespace Muljin.Utils
{
	public static class RandomStringGenerator
	{

		public static string Generate(int length, bool caseSensitive = false)
		{
			Guards.GreaterThan(length, 0, nameof(length));

			var rnd = new Random();

			var sb = new StringBuilder();

			for(var i = 0; i<length; i++)
			{
				sb.Append(GenerateChar(rnd, caseSensitive));
			}

			return sb.ToString();
		}

        // <summary>
        /// Generate a random password composed of special characters, numbers, capital and small letters
        /// </summary>
        /// <param name="categoryLength">length of character generated from a single category</param>
        /// <returns></returns>
        public static string GenerateRandomPassword(int categoryLength = 5)
        {
            //ascii
            var categories = new (int, int)[]
            {
                //(start, length)
                (32, 15),//special characters
                (48, 9),//numbers
                (65, 25),//capital letters
                (97, 25)//small letters
            };

            var passwordBuilder = new StringBuilder(categoryLength * categories.Length);

            foreach (var (start, len) in categories)
            {
                for (int i = 0; i < categoryLength; i++)
                {
                    var c = (char)(byte)RandomNumberGenerator.GetSingle(start + len, start);
                    passwordBuilder.Append(c);
                }
            }

            return passwordBuilder.ToString();
        }

        private static char GenerateChar(Random rnd, bool caseSensitive)
		{

			// chars A = 65, Z = 90, a = 97, z = 122

			var num = (int)rnd.Next(52);
			int res;

			// return number between 65-90 or 97-122
			if (caseSensitive)
			{
				res = 65 + num;
				if(res > 90)
				{
					res += 6;
				}
			}
			else
			{
				res = 97 + (num % 26);
			}

			return (char)res;
        }
	}
}

