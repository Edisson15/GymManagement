using GymManagement.Domain.Entities;

namespace GymManagement.Domain.Interfaces.Repositories
{
    public interface ITrainerRepository
    {
        Task<IEnumerable<Trainer>> GetAllAsync();

        Task<Trainer?> GetByIdAsync(int id);

        Task<Trainer> CreateAsync(Trainer trainer);

        Task UpdateAsync(Trainer trainer);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}