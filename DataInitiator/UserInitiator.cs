using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Models;
using FakeBilibili.Models.DomainModels;
using Microsoft.Extensions.DependencyInjection;

namespace FakeBilibili.DataInitiator
{
    public class UserInitiator
    {
        public static async Task Initial(IServiceProvider serviceProvider)
        {
            UserAndVideoDbContext context = serviceProvider.GetRequiredService<UserAndVideoDbContext>();
            if (!context.Users.Any())
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                int pictureSerial = 0;                  
                                
                for (int i = 0; i < 20; i++)
                {
                    pictureSerial = i % 4;
                    User user = new User()
                    {
                        AvatarLocation = Path.Combine(currentDirectory,$"{pictureSerial}.jpg"),
                        UserName = $"User{i+1}",
                        Id = i+1,
                        Email = $"User{i+1}@cnblog.com"
                    };                    

                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
