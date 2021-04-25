using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Muljin.Utils
{
    public class RandomNumberGenerator : IDisposable
    {
        private RNGCryptoServiceProvider _rngCryptoService = new RNGCryptoServiceProvider();


        public void Dispose()
        {
            _rngCryptoService.Dispose();
        }

        /// <summary>
        /// Generate a random integer
        /// </summary>
        /// <param name="max">Maximum value. Cannot be higher that int.MaxValue</param>
        /// <param name="min">Minimum value. Cannoy be less than int.MinimumValue</param>
        /// <returns></returns>
        public int Generate(int max, int min)
        {
            if(max < min)
            {
                throw new ArgumentException("Max cannot be less than min");
            }
            var bytes = new byte[4];
            _rngCryptoService.GetBytes(bytes);
            var val = BitConverter.ToUInt32(bytes, 0);
            var res = (int)Math.Ceiling(min + ( (decimal)val / (decimal)UInt32.MaxValue * max ));
            return res;
        }
    }
}
