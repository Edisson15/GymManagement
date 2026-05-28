using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace GymManagement.Domain.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IGenericRepository<Membership> _repository;

        private readonly ILogger<MembershipService> _logger;

        public MembershipService(
            IGenericRepository<Membership> repository,
            ILogger<MembershipService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET ALL
        public async Task<IEnumerable<Membership>> GetAllAsync()
        {
            _logger.LogInformation(
                "Consultando todas las membresías"
            );

            return await _repository.GetAllAsync();
        }

        // GET BY ID
        public async Task<Membership?> GetByIdAsync(int id)
        {
            _logger.LogInformation(
                "Consultando membresía con ID {Id}",
                id
            );

            var membership = await _repository
                .GetByIdAsync(id);

            if (membership == null)
            {
                _logger.LogWarning(
                    "Membresía con ID {Id} no encontrada",
                    id
                );
            }

            return membership;
        }

        // CREATE
        public async Task<Membership> CreateAsync(
            Membership membership)
        {
            _logger.LogInformation(
                "Intentando crear membresía {Name}",
                membership.Name
            );

            // VALIDACIONES
            if (string.IsNullOrWhiteSpace(
                membership.Name))
            {
                _logger.LogWarning(
                    "Intento de crear membresía sin nombre"
                );

                throw new Exception(
                    "El nombre es obligatorio"
                );
            }

            if (membership.Price <= 0)
            {
                _logger.LogWarning(
                    "Intento de crear membresía con precio inválido"
                );

                throw new Exception(
                    "El precio debe ser mayor a cero"
                );
            }

            var createdMembership =
                await _repository.CreateAsync(
                    membership
                );

            _logger.LogInformation(
                "Membresía creada correctamente con ID {Id}",
                createdMembership.Id
            );

            return createdMembership;
        }

        // UPDATE
        public async Task UpdateAsync(
            int id,
            Membership membership)
        {
            _logger.LogInformation(
                "Actualizando membresía con ID {Id}",
                id
            );

            var existing = await _repository
                .GetByIdAsync(id);

            if (existing == null)
            {
                _logger.LogWarning(
                    "No se encontró la membresía con ID {Id}",
                    id
                );

                throw new KeyNotFoundException(
                    "Membresía no encontrada"
                );
            }

            existing.Name = membership.Name;
            existing.Price = membership.Price;
            existing.Type = membership.Type;

            await _repository.UpdateAsync(existing);

            _logger.LogInformation(
                "Membresía con ID {Id} actualizada correctamente",
                id
            );
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation(
                "Eliminando membresía con ID {Id}",
                id
            );

            var exists = await _repository
                .ExistsAsync(id);

            if (!exists)
            {
                _logger.LogWarning(
                    "No se encontró la membresía con ID {Id}",
                    id
                );

                throw new KeyNotFoundException(
                    "Membresía no encontrada"
                );
            }

            await _repository.DeleteAsync(id);

            _logger.LogInformation(
                "Membresía con ID {Id} eliminada correctamente",
                id
            );
        }
    }
}