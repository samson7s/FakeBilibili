using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeBilibili.Infrastructure
{
    public class SaltGenerator
    {
        public static string GenerateSalt()
        {
            return GenerateSalt(8);
        }

        public static string GenerateSalt(int length)
        {
            if (length<=0)
            {
                return String.Empty;
            }

            StringBuilder salt = new StringBuilder();
            Random random=new Random();            
            StringBuilder saltCharList=new StringBuilder();
            //将小写字母加入到字符串中
            for (int i = 97; i <= 122; i++)
            {
                saltCharList.Append((char) i);
            }
            //将大写字母加入到字符串中
            for (int i = 65; i <=90; i++)
            {
                saltCharList.Append((char) i);
            }
            saltCharList.Append(0123456789);

            for (int saltIndex = 0; saltIndex < length; saltIndex++)
            {
                salt.Append(saltCharList[random.Next(61)]);
            }

            return salt.ToString();
        }
    }
}
