using Microsoft.EntityFrameworkCore;
using StudentAutorization.Data;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;

namespace StudentAutorization.Repositories.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<Course> AddAsync(Course course)
        {
            await _appDbContext.Courses.AddAsync(course);
            await _appDbContext.SaveChangesAsync();
            return course;
        }

        public async Task DeleteAsync(Course course)
        {
            _appDbContext.Courses.Remove(course);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var course = await _appDbContext.Courses
               .ToListAsync();
            return course;


        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _appDbContext.Courses.FindAsync(id);
        }

        public async Task UpdateAsync(Course course)
        {
            _appDbContext.Courses.Attach(course);
            _appDbContext.Entry(course).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
