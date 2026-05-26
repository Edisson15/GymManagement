using GymManagement.Domain.Entities;

namespace GymManagement.Domain.Interfaces.Services
{
    public interface IGymClassService
    {
        Task<IEnumerable<GymClass>> GetAllAsync();

        Task<GymClass?> GetByIdAsync(int id);

        Task<GymClass> CreateAsync(GymClass gymClass);

        Task UpdateAsync(int id, GymClass gymClass);

        Task DeleteAsync(int id);
    }
}