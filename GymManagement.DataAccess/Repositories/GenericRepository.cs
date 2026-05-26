using Microsoft.EntityFrameworkCore;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.DataAccess.Context;

namespace GymManagement.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GymDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(GymDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Agregamos 'virtual' para permitir que MemberRepository haga override con .Include()
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Agregamos 'virtual' para permitir personalización por ID
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }
    }
}