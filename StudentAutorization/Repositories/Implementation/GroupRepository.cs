using Microsoft.EntityFrameworkCore;
using StudentAutorization.Data;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;

namespace StudentAutorization.Repositories.Implementation
{
    public class GroupRepository:IGroupRepository
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

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            var group = await _appDbContext.Groups.Include(c=>c.Course)
               .ToListAsync();
            return group;


        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _appDbContext.Groups.FindAsync(id);
        }

        public async Task UpdateAsync(Group group)
        {
            _appDbContext.Groups.Attach(group);
            _appDbContext.Entry(group).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
