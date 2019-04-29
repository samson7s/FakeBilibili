using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBilibili.Models.DomainModels;

namespace FakeBilibili.Models
{
    public class LoginModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
