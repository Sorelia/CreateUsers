using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUsers
{
    class Combine_Hash_Salt
    {


        public static byte[] Combine(byte[] hashedPass, byte[] salt)
        {
            var value = new byte[hashedPass.Length + salt.Length];

            Buffer.BlockCopy(hashedPass, 0, value, 0, hashedPass.Length);
            Buffer.BlockCopy(salt, 0, value, hashedPass.Length, salt.Length);

            return value;

        }
    }
}
