﻿using System;
using Microsoft.EntityFrameworkCore;
using CourseMeetingEntitiesLib.dbo;

namespace CourseMeetingDbContextLib
{
    public class CourseMeetingDb : DbContext
    {

        public DbSet<Course> Courses {get;set;}
        public DbSet<CourseMeeting> CourseMeetings { get; set; }
        public DbSet<CourseMeetingParticipant> CoursesMeetingParticipants { get; set; }
        public DbSet<CourseSecundaryTeacher> CourseSecundaryTeachers { get; set; }


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

               

               c.ToTable("Courses");
           });
             

           //modelBuilder.Entity<Course>().HasKey(c => c.CID);

           //modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<CourseMeeting>(cm =>
            {
                cm.HasKey(k => k.MID);
            });


            modelBuilder.Entity<CourseMeetingParticipant>(c =>
            {
                c.HasOne(m => m.CourseMeeting)
                .WithMany(m => m.CourseMeetingParticipants);

                //c.HasOne(m => m.Student)
                //.WithMany(s => s.);//Courses

                c.HasKey(k => new {k.MID, k.SUID});
            });

            modelBuilder.Entity<CourseSecundaryTeacher>(t =>
            {
                t.HasKey(k => new {k.CID, k.STUID});
            });
          
        }

    }
}


