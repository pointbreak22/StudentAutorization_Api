using Microsoft.EntityFrameworkCore;
using StudentAutorization.Data;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;

namespace StudentAutorization.Repositories.Implementation
{
    public class TeacherRepository:ITeacherRepositoty
    {
        private readonly AppDbContext _appDbContext;

        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            await _appDbContext.Teachers.AddAsync(teacher);
            await _appDbContext.SaveChangesAsync();
            return teacher;
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            _appDbContext.Teachers.Remove(teacher);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            var teacherDto = _appDbContext.Teachers.Select(s => new TeacherDto
            {
                Id = s.Id,
                Name = s.Name,
               
                PictureId = s.PictureId,

                PictureName = s.Picture!.Src,
             



            });
            return teacherDto;


        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _appDbContext.Teachers.FindAsync(id);
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _appDbContext.Teachers.Attach(teacher);
            _appDbContext.Entry(teacher).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
