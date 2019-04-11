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
        public string VideoType { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime PublishDateTime { get; set; }

        [Required]
        public string Category { get; set; }

        public string Tag { get; set; }

        [Required]
        public int VideoView { get; set; }
    }
}
