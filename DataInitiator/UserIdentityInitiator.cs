using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Infrastructure;
using FakeBilibili.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FakeBilibili.DataInitiator
{
    public class UserIdentityInitiator
    {
        public static async Task Initial(IServiceProvider provider)
        {
            UserIdentityDbContext context = provider.GetRequiredService<UserIdentityDbContext>();
            Encryptor encryptor = new Encryptor();
            if (!context.Users.Any())
            {                
                for (int i = 0; i < 20; i++)
                {
                    UserIdentity user = new UserIdentity()
                    {
                        UserName = $"User{i+1}",
                        Password = encryptor.Encrypt($"User{i+1}"),
                        Id = i+1
                    };
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
