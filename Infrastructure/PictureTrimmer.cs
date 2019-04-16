using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace FakeBilibili.Infrastructure
{
    public class PictureTrimmer
    {        
        public static string GetLocalTrimmedPicture(string fileName)
        {
            string newLocation = fileName.Insert(fileName.LastIndexOf(".")+1, "min.");
            Image.FromFile(fileName).GetThumbnailImage(200, 200, null, IntPtr.Zero).Save(newLocation);
            return newLocation;
        }
    }
}
