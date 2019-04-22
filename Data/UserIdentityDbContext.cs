using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBilibili.Models;
using FakeBilibili.Models.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FakeBilibili.Data
{
    public class UserIdentityDbContext : DbContext
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options):base(options)
        { }

        public DbSet<UserIdentity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserIdentity>().HasIndex(u => new { u.Email }).IsUnique(true);
            modelBuilder.Entity<UserIdentity>().HasIndex(u => new { u.UserName }).IsUnique(true);
        }
    }
}
