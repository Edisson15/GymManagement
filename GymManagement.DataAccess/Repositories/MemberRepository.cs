using Microsoft.EntityFrameworkCore;
using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.DataAccess.Context;

namespace GymManagement.DataAccess.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(GymDbContext context) : base(context)
        {
        }

        // 1. Sobrescribimos el GetAll genérico para meter el Include
        public override async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _context.Members
                .Include(m => m.Membership) 
                .ToListAsync();
        }

        // 2. Sobrescribimos el GetById genérico para incluir también la membresía
        public override async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members
                .Include(m => m.Membership)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Member?> GetByEmailAsync(string email)
        {
            return await _context.Members
                .Include(m => m.Membership) 
                .FirstOrDefaultAsync(m => m.Email == email);
        }
    }
}