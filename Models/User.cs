using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBilibili.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public string AvatarType { get; set; }      

        /// <summary>
        /// 缩略图
        /// </summary>
        public byte[] AvatarThumbnail { get; set; }

        /// <summary>
        /// 作品
        /// </summary>
        public ICollection<Video> Works { get; set; }

        /// <summary>
        /// 关注，内部用 / 分隔
        /// </summary>
        public string Follows { get; set; }

        /// <summary>
        /// 粉丝
        /// </summary>
        public string Fans { get; set; }
    }
}
