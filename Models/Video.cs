using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBilibili.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        public string FileLocation { get; set; }     
        
        public byte[] Thumbnail { get; set; }

        public string ThumbnailType { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime PublishDateTime { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Required]
        public string Category { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 观看数
        /// </summary>
        [Required]
        public int VideoView { get; set; }
    }
}
