using StudentAutorization.Models.Main;

namespace StudentAutorization.Repositories.Interface
{
    public interface IPictureRepository
    {
        Task<IEnumerable<Picture>> GetAllAsync();
        Task<Picture> GetByIdAsync(int id);
        Task<Picture> AddAsync(Picture entity);
        Task UpdateAsync(Picture entity);
        Task DeleteAsync(Picture entity);

    }
}
