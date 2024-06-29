using StudentAutorization.Models.Main;

namespace StudentAutorization.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(Student entity);
        Task UpdateAsync(Student entity);
        Task DeleteAsync(Student entity);



    }
}
