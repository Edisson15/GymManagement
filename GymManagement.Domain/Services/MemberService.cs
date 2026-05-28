using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace GymManagement.Domain.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        private readonly ILogger<MemberService> _logger;

        public MemberService(
            IMemberRepository memberRepository,
            ILogger<MemberService> logger)
        {
            _memberRepository = memberRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            _logger.LogInformation(
                "Consultando todos los miembros"
            );

            return await _memberRepository.GetAllAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            _logger.LogInformation(
                "Consultando miembro con ID {Id}",
                id
            );

            var member = await _memberRepository
                .GetByIdAsync(id);

            if (member == null)
            {
                _logger.LogWarning(
                    "Miembro con ID {Id} no encontrado",
                    id
                );
            }

            return member;
        }

        public async Task<Member> CreateAsync(Member member)
        {
            _logger.LogInformation(
                "Intentando crear miembro con email {Email}",
                member.Email
            );

            // Validación de negocio
            var existing = await _memberRepository
                .GetByEmailAsync(member.Email);

            if (existing != null)
            {
                _logger.LogWarning(
                    "Ya existe un miembro con email {Email}",
                    member.Email
                );

                throw new InvalidOperationException(
                    "Ya existe un miembro con ese email"
                );
            }

            // Guardamos el registro
            var createdMember = await _memberRepository
                .CreateAsync(member);

            _logger.LogInformation(
                "Miembro creado correctamente con ID {Id}",
                createdMember.Id
            );

            // Recargamos con Include()
            var fullMember = await _memberRepository
                .GetByIdAsync(createdMember.Id);

            return fullMember ?? createdMember;
        }

        public async Task UpdateAsync(int id, Member member)
        {
            _logger.LogInformation(
                "Actualizando miembro con ID {Id}",
                id
            );

            var existing = await _memberRepository
                .GetByIdAsync(id);

            if (existing == null)
            {
                _logger.LogWarning(
                    "No se encontró el miembro con ID {Id}",
                    id
                );

                throw new KeyNotFoundException(
                    "Miembro no encontrado"
                );
            }

            existing.Name = member.Name;
            existing.Email = member.Email;
            existing.MembershipId = member.MembershipId;

            await _memberRepository
                .UpdateAsync(existing);

            _logger.LogInformation(
                "Miembro con ID {Id} actualizado correctamente",
                id
            );
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation(
                "Eliminando miembro con ID {Id}",
                id
            );

            var exists = await _memberRepository
                .ExistsAsync(id);

            if (!exists)
            {
                _logger.LogWarning(
                    "No se encontró el miembro con ID {Id}",
                    id
                );

                throw new KeyNotFoundException(
                    "Miembro no encontrado"
                );
            }

            await _memberRepository.DeleteAsync(id);

            _logger.LogInformation(
                "Miembro con ID {Id} eliminado correctamente",
                id
            );
        }
    }
}