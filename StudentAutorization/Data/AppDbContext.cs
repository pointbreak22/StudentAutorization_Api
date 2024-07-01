using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAutorization.Models.Autorization;
using StudentAutorization.Models.Main;
using System.Reflection.Metadata;

namespace StudentAutorization.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           

        //    modelBuilder.Entity<Student>()
        //        .HasOne(p => p.Group)
        //        .WithMany(t => t.Students)
        //        .HasForeignKey(p => p.GroupId);

        //    modelBuilder.Entity<Group>()
        //        .HasOne(p => p.Teacher)
        //        .WithMany(t => t.Groups)
        //        .HasForeignKey(p => p.TeacherId);

        //    base.OnModelCreating(modelBuilder);

        //}


    }
}
