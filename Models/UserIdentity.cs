using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FakeBilibili.Models
{
    public class UserIdentity
    {
        [Key]
        public int Id { get; set; }

        [Required]        
        public string Password { get; set; }
    }
}