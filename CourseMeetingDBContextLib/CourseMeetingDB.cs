using System;
using Microsoft.EntityFrameworkCore;
using CourseMeetingEntitiesLib;

namespace CourseMeetingDBContextLib
{
    public class CourseMeetingDb : DbContext
    {

        public DbSet<Course> Courses {get;set;}
        public DbSet<Course> CourseMeetings { get; set; }
        public DbSet<Course> CoursesMeetingParticipants { get; set; }
        public DbSet<Course> CourseSecundaryTeachers { get; set; }
        public DbSet<Course> Roles { get; set; }
        public DbSet<Course> Users { get; set; }

        public CourseMeetingDb(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Course>(c =>
           {
               c.HasKey(m => m.CID);

               c.HasMany(m => m.CourseMeetings)
               .WithOne(m => m.Course);

               c.HasMany(st => st.STeachers)
               .WithOne(st => st.Course);
           });

            modelBuilder.Entity<CourseMeeting>(cm =>
            {
                cm.HasKey(k => k.MID);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(k => k.Id);

                u.Property(p => p.Id)
                .HasColumnName("UID");
            });

            modelBuilder.Entity<CourseMeetingParticipant>(c =>
            {
                c.HasOne(m => m.CourseMeeting)
                .WithMany(m => m.CourseMeetingParticipants);

                c.HasOne(m => m.Student)
                .WithMany(s => s.)
            });

                
        }

    }
}
