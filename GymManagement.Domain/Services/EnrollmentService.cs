using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;

namespace GymManagement.Domain.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;

        public EnrollmentService(IEnrollmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Enrollment> CreateAsync(Enrollment enrollment)
        {
            var created = await _repository.CreateAsync(enrollment);

            var fullEnrollment = await _repository.GetByIdAsync(created.Id);

            return fullEnrollment ?? created;
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _repository.ExistsAsync(id);

            if (!exists)
                throw new KeyNotFoundException("Enrollment no encontrado");

            await _repository.DeleteAsync(id);
        }
    }
}