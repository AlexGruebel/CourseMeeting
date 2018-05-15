using System;
using Microsoft.EntityFrameworkCore;
using CourseMeetingEntitiesLib.dbo;

namespace CourseMeetingDbContextLib
{
    public class CourseMeetingDb : DbContext
    {

        public DbSet<Course> Courses {get;set;}
        public DbSet<CourseMeeting> CourseMeetings { get; set; }
        public DbSet<CourseMeetingParticipant> CourseMeetingParticipants { get; set; }
        public DbSet<CourseSecundaryTeacher> CourseSecundaryTeachers { get; set; }
        public DbSet<MeetingWithCountParticpants> MeetingWithCountParticpants {get;set;}
        public DbSet<Teacher> Teachers { get; set; }

        public CourseMeetingDb(DbContextOptions<CourseMeetingDb> options) : base(options)
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

                cm.Property(p => p.MID)
                   .UseSqlServerIdentityColumn();

                cm.HasMany(m => m.CourseMeetingParticipants).WithOne(m => m.CourseMeeting);    

                cm.HasOne(m => m.Teacher).WithMany(m => m.CourseMeetings).HasForeignKey(m => m.TUID);
            });


            modelBuilder.Entity<CourseMeetingParticipant>(c =>
            {    
                c.HasKey(k => new {k.MID, k.SUID});
                
            });

            modelBuilder.Entity<CourseSecundaryTeacher>(t =>
            {
                t.HasKey(k => new {k.CID, k.STUID});
            });
          
            modelBuilder.Entity<MeetingWithCountParticpants>(m =>
            {
                m.HasKey(k => new {k.CID, k.MID});
                m.Property(p => p.CountParticpants).HasColumnName("Participants");
                m.ToTable("CourseMeetingsWithCountParticipants_View");
            });

            modelBuilder.Entity<Teacher>(u => 
            {
                u.HasKey(k => k.UID);
                u.HasQueryFilter(f => f.RoleID == "B");
                u.ToTable("Users_View");
            });


        }
    }
}