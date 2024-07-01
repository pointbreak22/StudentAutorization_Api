using Microsoft.EntityFrameworkCore;
using StudentAutorization.Data;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;

namespace StudentAutorization.Repositories.Implementation
{
    public  class Repository<T> : IRepository<T> where T : class   //не используется
     {
  
        private readonly AppDbContext _appDbContext;
        protected DbSet<T> _dbSet;
        public Repository(AppDbContext appDbContext) {
             _appDbContext = appDbContext;
            _dbSet=appDbContext.Set<T>();
        }
        
        
        public async Task<T> AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
           await _appDbContext.SaveChangesAsync();
           return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Group))
            {

                var groups= await _appDbContext.Groups
                     .Include(c => c.Course)
                     .Include(t => t.Teacher)
                    .ToListAsync();

                return (IEnumerable<T>) groups;
            }

            //if (typeof(T) == typeof(Student))
            //{
            //    return (IEnumerable<T>)await _appDbContext.Students              
            //        .Include(t => t.Group).ToListAsync();
            //}

            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async  Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
           _dbSet.Attach(entity);
           _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
