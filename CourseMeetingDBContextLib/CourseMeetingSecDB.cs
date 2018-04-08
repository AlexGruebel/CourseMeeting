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


        public CourseMeetingSecDB(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("sec");

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(k => k.Id);

                u.Property(p => p.Id)
                .HasColumnName("UID");

                u.ToTable("Users");

            });



            /*
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(k => k.Id);

                u.Property(p => p.Id)
                .HasColumnName("UID");

            });
            */
        }

    }
}
