using GymManagement.Domain.Entities;

namespace GymManagement.Domain.Interfaces.Services
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();

        Task<Enrollment?> GetByIdAsync(int id);

        Task<Enrollment> CreateAsync(Enrollment enrollment);

        Task DeleteAsync(int id);
    }
}