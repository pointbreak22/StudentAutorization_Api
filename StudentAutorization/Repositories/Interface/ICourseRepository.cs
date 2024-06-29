using StudentAutorization.Models.Main;

namespace StudentAutorization.Repositories.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<Course> AddAsync(Course entity);
        Task UpdateAsync(Course entity);
        Task DeleteAsync(Course entity);
    }
}
