using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBilibili.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBilibili.Data
{
    public class UserAndVideoDbContext:DbContext
    {
        public UserAndVideoDbContext(DbContextOptions<UserAndVideoDbContext> options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
