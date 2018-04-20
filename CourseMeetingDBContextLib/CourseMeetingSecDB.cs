using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CourseMeetingEntitiesLib.sec;

namespace CourseMeetingDbContextLib
{
    public class CourseMeetingSecDB : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        public DbSet<IdentityUserRole<string>> IdentityUserRole {get;set;}
        public DbSet<IdentityRoleClaim<string>> IdentityRoleClaim {get;set;}

        public CourseMeetingSecDB(DbContextOptions<CourseMeetingSecDB> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("sec");

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("UID");
                //u.HasOne(r => r.Role).WithOne(r => r.User);
                //u.HasOne(i => i.IdentityUserRole).WithOne(i => i.User);
                u.ToTable("Users");
            });

            modelBuilder.Entity<Role>(r =>{
                r.Property(p => p.Id).HasColumnName("RID");
                r.Property(p => p.Name).HasColumnName("RName");
                //r.HasOne(i => i.IdentityUserRole).WithOne(i => i.Role);
                r.ToTable("Roles");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(e =>{
                e.HasKey(i => new {i.RoleId, i.UserId});
                //e.HasOne(i => i.User).WithOne(u => u.IdentityUserRole);
                //e.HasOne(i => i.Role).WithOne(r => r.IdentityUserRole);
                e.ToTable("IdentityUserRole");
            });
                
        }

    }
}
