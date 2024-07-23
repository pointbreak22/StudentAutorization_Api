using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAutorization.Models.Autorization;
using StudentAutorization.Models.Main;

namespace StudentAutorization.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Picture> Pictures { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }




    }
}
