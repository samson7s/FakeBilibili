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
        public static void GetLocalTrimmedPicture(string fileName)
        {
            string newLocation = fileName.Insert(fileName.LastIndexOf("."), "min");
            Image.FromFile(fileName).GetThumbnailImage(100, 100, null, IntPtr.Zero).Save(newLocation);
        }
    }
}
