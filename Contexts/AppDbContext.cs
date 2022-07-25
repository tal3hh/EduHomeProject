using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmirProje.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElmirProje.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }



        public DbSet<Subscribee> Subscribees { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<BioTable> BioTables { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }
        public DbSet<CourseFeatures> CourseFeatures { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventTeacher> EventTeachers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<NoticeBoard> NoticeBoards { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TagTable> TagTables { get; set; }
    }
}
