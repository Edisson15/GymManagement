using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;

namespace GymManagement.Domain.Services
{
    public class GymClassService : IGymClassService
    {
        private readonly IGymClassRepository _repository;

        public GymClassService(IGymClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GymClass>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GymClass?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<GymClass> CreateAsync(GymClass gymClass)
        {
            return await _repository.CreateAsync(gymClass);
        }

        public async Task UpdateAsync(int id, GymClass gymClass)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Clase no encontrada");

            existing.Name = gymClass.Name;
            existing.TrainerId = gymClass.TrainerId;
            existing.Schedule = gymClass.Schedule;
            existing.Capacity = gymClass.Capacity;
            existing.Status = gymClass.Status;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _repository.ExistsAsync(id);

            if (!exists)
                throw new KeyNotFoundException("Clase no encontrada");

            await _repository.DeleteAsync(id);
        }
    }
}