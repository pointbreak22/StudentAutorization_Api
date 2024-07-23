using StudentAutorization.Models.Main;
using StudentAutorization.ViewModel;

namespace StudentAutorization.Repositories.Interface
{
    public interface ITeacherRepositoty
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher entity);
        Task UpdateAsync(Teacher entity);
        Task DeleteAsync(Teacher entity);

    }
}
