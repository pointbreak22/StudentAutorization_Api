using Microsoft.EntityFrameworkCore;
using StudentAutorization.Data;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;

namespace StudentAutorization.Repositories.Implementation
{
    public class StudentRepository:IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public  StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task< Student> AddAsync( Student student)
        {
            await _appDbContext. Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }

        public async Task DeleteAsync( Student student)
        {
            _appDbContext. Students.Remove(student);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable< Student>> GetAllAsync()
        {
            var student = await _appDbContext. Students
               .ToListAsync();
            return student;


        }

        public async Task< Student> GetByIdAsync(int id)
        {
            return await _appDbContext. Students.FindAsync(id);
        }

        public async Task UpdateAsync(Student student)
        {
            _appDbContext.Students.Attach(student);
            _appDbContext.Entry(student).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
