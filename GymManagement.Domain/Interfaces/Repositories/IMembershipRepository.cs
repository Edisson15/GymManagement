using GymManagement.Domain.Entities;

namespace GymManagement.Domain.Interfaces.Repositories
{
    public interface IMembershipRepository
    {
        Task<IEnumerable<Membership>> GetAllAsync();

        Task<Membership?> GetByIdAsync(int id);

        Task<Membership> CreateAsync(Membership membership);

        Task UpdateAsync(Membership membership);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}