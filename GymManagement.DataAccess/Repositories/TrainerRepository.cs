using GymManagement.DataAccess.Context;
using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.DataAccess.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly GymDbContext _context;

        public TrainerRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task<Trainer?> GetByIdAsync(int id)
        {
            return await _context.Trainers.FindAsync(id);
        }

        public async Task<Trainer> CreateAsync(Trainer trainer)
        {
            _context.Trainers.Add(trainer);

            await _context.SaveChangesAsync();

            return trainer;
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            _context.Trainers.Update(trainer);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Trainers.AnyAsync(x => x.Id == id);
        }
    }
}