using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Models;
using FakeBilibili.Models.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FakeBilibili.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private UserIdentityDbContext _identityDbContext;        

        public LoginController(IConfiguration config,UserIdentityDbContext identityDbContext)
        {
            _config = config;
            _identityDbContext = identityDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Account account)
        {
            var user = ValidateUser(account);
            if (user!=null)
            {
                
            }

            return NotFound();
        }

        UserIdentity ValidateUser(Account account)
        {
            var user= _identityDbContext.Users.FirstOrDefault(
                u => u.Id == account.Id && u.Password == account.Password);
            if (user!=null)
            {
                return user;
            }
            return null;
        }

        string GenerateJsonWebToken(UserIdentity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            return "";
        }
    }
}