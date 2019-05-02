using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Infrastructure;
using FakeBilibili.Models;
using FakeBilibili.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FakeBilibili.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private UserIdentityDbContext _identityDbContext;
        private UserAndVideoDbContext _userAndVideoDbContext;
        private IEncrypt _encryptor;

        public AccountController(IConfiguration config, IEncrypt encryptor, UserIdentityDbContext identityDbContext,UserAndVideoDbContext userAndVideoDbContext)
        {
            _config = config;
            _identityDbContext = identityDbContext;
            _encryptor = encryptor;
            _userAndVideoDbContext = userAndVideoDbContext;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel account)
        {
            if (account.Account == null || account.Password == null)
            {
                return Unauthorized();
            }

            var user = await ValidateUser(account);
            if (user != null)
            {
                var tokenString = GenerateJsonWebToken(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> PersonalInfo()
        {
            string userName=User.FindFirst(JwtRegisteredClaimNames.Sub).Value;
            User user = _userAndVideoDbContext.Users.Include(u=>u.Works).FirstOrDefault(u => u.UserName == userName);
            if (user==null)
            {
                return Unauthorized();
            }
            return Ok(new {UserName = user.UserName});
        }

        async Task<UserIdentity> ValidateUser(LoginModel account)
        {
            UserIdentity user = await GetUser(account);

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

        [Route("play")]
        public IActionResult ForPlay()
        {
            return Ok(new{fuck="fuck you"});
        }

        async Task<UserIdentity> GetUser(LoginModel account)
        {
            string regexId = @"^\d+$";
            string regexUserName = @"^[a-zA-Z]+[a-zA-Z\d]*$";
            string regexEmail = @"[a-zA-Z\d]+@[a-zA-Z\d]+.";

            UserIdentity user = new UserIdentity();
            if (Regex.IsMatch(account.Account, regexId))
            {
                user = await _identityDbContext.Users.FirstOrDefaultAsync(u => u.Id == Int32.Parse(account.Account));
            }
            else if (Regex.IsMatch(account.Account, regexUserName))
            {
                user = await _identityDbContext.Users.FirstOrDefaultAsync(u => u.UserName == account.Account);
            }
            else if (Regex.IsMatch(account.Account, regexEmail))
            {
                user = await _identityDbContext.Users.FirstOrDefaultAsync(u => u.Email == account.Account);
            }
            return user;
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