using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Infrastructure;
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
        private IEncrypt _encryptor;

        public LoginController(IConfiguration config, IEncrypt encryptor, UserIdentityDbContext identityDbContext)
        {
            _config = config;
            _identityDbContext = identityDbContext;
            _encryptor = encryptor;
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            var user = ValidateUser(account);
            if (user != null)
            {
                var tokenString = GenerateJsonWebToken(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        UserIdentity ValidateUser(Account account)
        {
            UserIdentity user = _identityDbContext.Users.FirstOrDefault(u => u.Id == account.Id);
            if (user == null)
            {
                return null;
            }

            var hashPassword = _encryptor.Encrypt(account.Password, user.Salt);
            if (user.Password == hashPassword)
            {
                return user;
            }

            return null;
        }

        string GenerateJsonWebToken(UserIdentity user)
        {
            //定义密钥
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //定义要使用的密钥和进行哈希计算的算法
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //定义待添加 Jwt 的 payload 字段
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //定义 Jwt 的 payload 字段
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}