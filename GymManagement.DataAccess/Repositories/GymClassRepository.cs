using GymManagement.DataAccess.Context;
using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.DataAccess.Repositories
{
    public class GymClassRepository : IGymClassRepository
    {
        private readonly GymDbContext _context;

        public GymClassRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GymClass>> GetAllAsync()
        {
            return await _context.GymClasses.ToListAsync();
        }

        public async Task<GymClass?> GetByIdAsync(int id)
        {
            return await _context.GymClasses.FindAsync(id);
        }

        public async Task<GymClass> CreateAsync(GymClass gymClass)
        {
            _context.GymClasses.Add(gymClass);

            await _context.SaveChangesAsync();

            return gymClass;
        }

        public async Task UpdateAsync(GymClass gymClass)
        {
            _context.GymClasses.Update(gymClass);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gymClass = await _context.GymClasses.FindAsync(id);

            if (gymClass != null)
            {
                _context.GymClasses.Remove(gymClass);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.GymClasses.AnyAsync(x => x.Id == id);
        }
    }
}