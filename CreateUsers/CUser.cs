using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUsers
{
    class CUser
    {
        private static CUser user;
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string salt;

        public string SaltVal
        {
            get { return salt; }
            set { salt = value; }
        }

        private string key1;

        public string Key1
        {
            get { return key1; }
            set { key1 = value; }
        }

        private string key2;

        public string Key2
        {
            get { return key2; }
            set { key2 = value; }
        }




        public CUser(string username, string password, string salt, string key1, string key2)
        {
            Username = username;
            Password = password;
            SaltVal = salt;
            Key1 = key1;
            Key2 = key2;
        }

        public static CUser Create(string username, string password)
        {
            byte[] firstKey = Key.GenerateKey();
            byte[] pass = Hash.ComputeHmachSHA512(Encoding.UTF8.GetBytes(password), firstKey);
            byte[] newSalt = Salt.GenerateSalt();
            Salt.lastSalt = newSalt;
            byte[] secondKey = Key.GenerateKey();
            byte[] hashedSalt = Combine_Hash_Salt.Combine(pass, newSalt);
            string saltHashedHMACH = Convert.ToBase64String(Hash.ComputeSHA512(hashedSalt));

            user = new CUser(username, saltHashedHMACH, Convert.ToBase64String(newSalt), Convert.ToBase64String(firstKey), Convert.ToBase64String(secondKey));

            return user;
        }
    }
}
