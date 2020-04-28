using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SGNWebAppCli.Helpers
{
    public class Utility
    {
        private const string _SALT = "yCcj^&G%3ebY9";
        public static string Encrypt(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(_SALT + password);
            using(SHA512 sha512Hash = SHA512.Create())
            {
                byte[] hashBytes = sha512Hash.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
