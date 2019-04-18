using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FakeBilibili.Infrastructure
{
    public class Encryptor : IEncrypt
    {
        private readonly SHA256 sha256;

        public Encryptor()
        {
            sha256 = SHA256.Create();
        }

        public string Encrypt(string password, string salt)
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            StringBuilder hashPassword = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                hashPassword.Append(hashByte);
            }
            return hashPassword.ToString();
        }
    }
}
