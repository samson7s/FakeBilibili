using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBilibili.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FakeBilibili.Data
{
    public class UserIdentityDbContext : DbContext
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options):base(options)
        { }

        public DbSet<UserIdentity> Users { get; set; }
    }
}
