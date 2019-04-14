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
using FakeBilibili.Migrations.UserAndVideoDb;
using FakeBilibili.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FakeBilibili.DataInitiator
{
    public class UserInitiator
    {
        public static async Task InitialUsers(IServiceProvider serviceProvider)
        {
            UserAndVideoDbContext context = serviceProvider.GetRequiredService<UserAndVideoDbContext>();
            if (!context.Users.Any())
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                int pictureSerial = 0;                
                                
                for (int i = 0; i < 20; i++)
                {
                    pictureSerial = i % 4;
                    byte[] picData=await File.ReadAllBytesAsync($"{currentDirectory}/Avatar/{pictureSerial}.jpg");
                    User user = new User()
                    {
                        AvatarThumbnail = picData,
                        AvatarType = "image/jpg"
                    };                    

                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
