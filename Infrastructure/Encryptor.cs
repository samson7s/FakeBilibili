using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FakeBilibili.Infrastructure
{
    public class Encryptor:IEncrypt
    {
        private MD5 md5;

        public Encryptor()
        {
            md5 = MD5.Create();
        }

        public string Encrypt(string password)
        {
            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder hashPassword = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                hashPassword.Append(hashByte);
            }
            return hashPassword.ToString();
        }
    }
}
