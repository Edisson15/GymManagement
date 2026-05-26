using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.DataAccess.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly Context.GymDbContext _context;

        public MembershipRepository(Context.GymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Membership>> GetAllAsync()
        {
            return await _context.Memberships.ToListAsync();
        }

        public async Task<Membership?> GetByIdAsync(int id)
        {
            return await _context.Memberships.FindAsync(id);
        }

        public async Task<Membership> CreateAsync(Membership membership)
        {
            _context.Memberships.Add(membership);

            await _context.SaveChangesAsync();

            return membership;
        }

        public async Task UpdateAsync(Membership membership)
        {
            _context.Memberships.Update(membership);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var membership = await _context.Memberships.FindAsync(id);

            if (membership != null)
            {
                _context.Memberships.Remove(membership);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Memberships.AnyAsync(x => x.Id == id);
        }
    }
}