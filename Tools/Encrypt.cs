using System.Text;
using System;
using XSystem.Security.Cryptography;

namespace AARCOAPI.Tools
{
    public class Encrypt
    {
        public static string GetSHA256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
