using StudentAutorization.Models.Main;
using StudentAutorization.ViewModel;

namespace StudentAutorization.Repositories.Interface
{
    public interface IGroupRepository
    {
        Task<IEnumerable<GroupDto>> GetAllAsync();

        Task<IEnumerable<StudentDto>> GetStudents(int id);
        Task<Group> GetByIdAsync(int id);
        Task<Group> AddAsync(Group entity);
        Task UpdateAsync(Group entity);
        Task DeleteAsync(Group entity);
    }
}
