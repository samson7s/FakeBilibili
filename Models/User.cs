using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBilibili.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Video> Works { get; set; }

        public string Follows { get; set; }

        public string Fans { get; set; }
    }
}
