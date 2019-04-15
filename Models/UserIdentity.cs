using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FakeBilibili.Models
{
    public class UserIdentity
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]        
        public string Password { get; set; }
    }
}