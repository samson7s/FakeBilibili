using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBilibili.Models.DomainModels;

namespace FakeBilibili.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public LoginType LoginType { get; set; }
    }
}
