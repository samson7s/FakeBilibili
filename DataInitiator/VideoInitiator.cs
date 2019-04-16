using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Infrastructure;
using FakeBilibili.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Model;

namespace FakeBilibili.DataInitiator
{
    public class VideoInitiator
    {
        public static async Task Initial(IServiceProvider provider)
        {
            FFmpeg.ExecutablesPath = @"D:\office softwares\FFMpeg";

            UserAndVideoDbContext context = provider.GetRequiredService<UserAndVideoDbContext>();
            string videoDirectory = Path.Combine(Directory.GetCurrentDirectory(),"Video");

            User author = context.Users.Include(u=>u.Works).FirstOrDefault(u=>u.Id==1);

            if (!context.Videos.Any())
            {                
                for (int i = 1; i <= 6; i++)
                {                    
                    string videoPath = Path.Combine(videoDirectory, $"{i}.mp4");
                    string picPath = Path.Combine(videoDirectory, $"{i}.jpg");

                    IMediaInfo mediaInfo = await MediaInfo.Get(videoPath);
                    Conversion.Snapshot(videoPath, picPath,
                        TimeSpan.FromSeconds(0)).Start().Wait();

                    Video video = new Video()
                    {
                        Title = $"轻音少女 第{i} 集",
                        Author = context.Users.FirstOrDefault(u => u.Id == 0),
                        Category = Category.番剧,
                        FileLocation = videoPath,
                        Duration = mediaInfo.Duration,                        
                        PublishDateTime = DateTime.Now,
                        Thumbnail = File.ReadAllBytes(PictureTrimmer.GetLocalTrimmedPicture(picPath)),
                        ThumbnailType = "image/jpg",
                        Tag = "轻音少女",
                        VideoView = 0
                    };
                    author.Works.Add(video);
                    await context.Videos.AddAsync(video);
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
