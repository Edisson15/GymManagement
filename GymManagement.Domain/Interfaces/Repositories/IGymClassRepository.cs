using GymManagement.Domain.Entities;

namespace GymManagement.Domain.Interfaces.Repositories
{
    public interface IGymClassRepository
    {
        Task<IEnumerable<GymClass>> GetAllAsync();

        Task<GymClass?> GetByIdAsync(int id);

        Task<GymClass> CreateAsync(GymClass gymClass);

        Task UpdateAsync(GymClass gymClass);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}