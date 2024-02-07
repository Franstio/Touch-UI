using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP1.Lib
{
    public static class EncUtil
    {
        public static string Hmac512Hash(this string val)
        {
            byte[] key = Encoding.UTF8.GetBytes("asjdlnkcnalnaehneuvnq1uf9q91fvbcibnckncknkzxn=13fkanp33922acnae");
            byte[] plaintext = Encoding.UTF8.GetBytes(val);
            using (var hash = new HMACSHA512(key))
            {
                 byte[] result = hash.ComputeHash(plaintext);
                return Convert.ToBase64String(result);
            }
        }
    }
}
