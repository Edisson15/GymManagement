using GymManagement.Domain.Entities;

namespace GymManagement.Domain.Interfaces.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();

        Task<Enrollment?> GetByIdAsync(int id);

        Task<Enrollment> CreateAsync(Enrollment enrollment);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}