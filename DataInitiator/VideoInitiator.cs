using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Infrastructure;
using FakeBilibili.Models;
using FakeBilibili.Models.DomainModels;
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
            string videoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Video");

            User author = context.Users.Include(u => u.Works).FirstOrDefault(u => u.Id == 1);

            if (!context.Videos.Any())
            {
                for (int i = 1; i <= 6; i++)
                {
                    string videoPath = Path.Combine(videoDirectory, $"{i}.mp4");
                    string picPath = Path.Combine(videoDirectory, $"{i}.jpg");

                    if (File.Exists(picPath))
                    {
                        File.Delete(picPath);
                    }

                    //获取视频信息
                    IMediaInfo mediaInfo = await MediaInfo.Get(videoPath);
                    //以 0 秒时的画面作为封面图并保存在本地
                    Conversion.Snapshot(videoPath, picPath,
                        TimeSpan.FromSeconds(0)).Start().Wait();

                    Video video = new Video()
                    {
                        Title = $"轻音少女 第{i}集",
                        Author = context.Users.FirstOrDefault(u => u.Id == 0),
                        Category = Category.番剧,
                        VideoLocation = videoPath,
                        Duration = mediaInfo.Duration,
                        PublishDateTime = DateTime.Now,
                        ThumbnailLocation = PictureTrimmer.GetLocalTrimmedPicture(picPath),
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
