using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeBilibili.Models.DomainModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string AvatarLocation { get; set; }

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
