using StudentAutorization.Models.Main;

namespace StudentAutorization.Repositories.Interface
{
    public interface ITeacherRepositoty
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher entity);
        Task UpdateAsync(Teacher entity);
        Task DeleteAsync(Teacher entity);

    }
}
