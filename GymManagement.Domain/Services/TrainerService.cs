using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;

namespace GymManagement.Domain.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _repository;

        public TrainerService(ITrainerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Trainer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Trainer> CreateAsync(Trainer trainer)
        {
            return await _repository.CreateAsync(trainer);
        }

        public async Task UpdateAsync(int id, Trainer trainer)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Trainer no encontrado");

            existing.Name = trainer.Name;
            existing.Specialty = trainer.Specialty;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _repository.ExistsAsync(id);

            if (!exists)
                throw new KeyNotFoundException("Trainer no encontrado");

            await _repository.DeleteAsync(id);
        }
    }
}