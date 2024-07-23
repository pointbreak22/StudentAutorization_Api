using Microsoft.EntityFrameworkCore;
using StudentAutorization.Data;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;

namespace StudentAutorization.Repositories.Implementation
{
    public class PictureRepository : IPictureRepository
    {
        private readonly AppDbContext _appDbContext;

        public PictureRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<Picture> AddAsync(Picture picture)
        {
            await _appDbContext.Pictures.AddAsync(picture);
            await _appDbContext.SaveChangesAsync();
            return picture;
        }

        public async Task DeleteAsync(Picture picture)
        {
            _appDbContext.Pictures.Remove(picture);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Picture>> GetAllAsync()
        {
            var picture = await _appDbContext.Pictures
               .ToListAsync();
            return picture;


        }

        public async Task<Picture> GetByIdAsync(int id)
        {
            return await _appDbContext.Pictures.FindAsync(id);
        }

        public async Task UpdateAsync(Picture picture)
        {
            _appDbContext.Pictures.Attach(picture);
            _appDbContext.Entry(picture).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
