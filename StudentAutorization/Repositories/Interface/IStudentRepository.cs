using StudentAutorization.Models.Main;
using StudentAutorization.ViewModel;

namespace StudentAutorization.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(Student entity);
        Task UpdateAsync(Student entity);
        Task DeleteAsync(Student entity);



    }
}
