using Microsoft.EntityFrameworkCore;
using StudentAutorization.Data;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;

namespace StudentAutorization.Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _appDbContext;

        public GroupRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<Group> AddAsync(Group group)
        {
            await _appDbContext.Groups.AddAsync(group);
            await _appDbContext.SaveChangesAsync();
            return group;
        }

        public async Task DeleteAsync(Group group)
        {
            _appDbContext.Groups.Remove(group);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            var groupDto = _appDbContext.Groups.Select(g => new GroupDto
            {
                Id = g.Id,
                Name = g.Name,
                Specialty = g.Specialty,
                Year = g.Year,
                CourseName = g.Course!.Name,
                TeacherName = g.Teacher!.Name



            });
            return groupDto;


        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _appDbContext.Groups.FindAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetStudents(int id)
        {
            var studentDto = _appDbContext.Students.Where(g => g.GroupId == id).Select(s => new StudentDto
            {
                Id = s.Id,
                FIO = s.FIO,
                NumberPhone = s.NumberPhone,

                PictureName = s.Picture!.Src,
                GroupName = s.Group!.Name



            });
            return studentDto;
        }

        public async Task UpdateAsync(Group group)
        {
            _appDbContext.Groups.Attach(group);
            _appDbContext.Entry(group).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
