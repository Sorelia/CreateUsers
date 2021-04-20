using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreateUsers
{
    class Key
    {
        private static int keySize = 32;

        /// <summary>
        /// Auto-Generates a key of a byte size 32
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateKey()
        {
            using (var cryptoGenerator = new RNGCryptoServiceProvider())
            {
                var key = new byte[keySize];
                cryptoGenerator.GetBytes(key);

                return key;
            }
        }
    }
}
