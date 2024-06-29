using StudentAutorization.Models.Main;

namespace StudentAutorization.Repositories.Interface
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(int id);
        Task<Group> AddAsync(Group entity);
        Task UpdateAsync(Group entity);
        Task DeleteAsync(Group entity);
    }
}
