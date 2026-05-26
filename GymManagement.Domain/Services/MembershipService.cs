using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;

namespace GymManagement.Domain.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _repository;

        public MembershipService(IMembershipRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Membership>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Membership?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Membership> CreateAsync(Membership membership)
        {
            return await _repository.CreateAsync(membership);
        }

        public async Task UpdateAsync(int id, Membership membership)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Membership no encontrado");

            existing.Name = membership.Name;
            existing.Price = membership.Price;
            existing.Type = membership.Type;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _repository.ExistsAsync(id);

            if (!exists)
                throw new KeyNotFoundException("Membership no encontrado");

            await _repository.DeleteAsync(id);
        }
    }
}