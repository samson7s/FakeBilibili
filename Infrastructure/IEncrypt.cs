using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBilibili.Infrastructure
{
    public interface IEncrypt
    {
        string Encrypt(string password,string salt);
    }
}
