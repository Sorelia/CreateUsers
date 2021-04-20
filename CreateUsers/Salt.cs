using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreateUsers
{
    class Salt
    {

        private static int saltSize = 32;
        public static byte[] lastSalt;


        /// <summary>
        /// Auto-Generates a key of a byte size 32
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateSalt()
        {
            using (var cryptoGenerator = new RNGCryptoServiceProvider())
            {
                var salt = new byte[saltSize];
                cryptoGenerator.GetBytes(salt);

                return salt;
            }
        }

    }
}
