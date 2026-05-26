using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Repositories;
using GymManagement.Domain.Interfaces.Services;

namespace GymManagement.Domain.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<Member> CreateAsync(Member member)
        {
            // VALIDACIÓN DE NEGOCIO (igual a SportsLeague)
            var existing = await _memberRepository.GetByEmailAsync(member.Email);
            if (existing != null)
                throw new InvalidOperationException("Ya existe un miembro con ese email");

            return await _memberRepository.CreateAsync(member);
        }

        public async Task UpdateAsync(int id, Member member)
        {
            var existing = await _memberRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Miembro no encontrado");

            existing.Name = member.Name;
            existing.Email = member.Email;
            existing.MembershipId = member.MembershipId;

            await _memberRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _memberRepository.ExistsAsync(id);
            if (!exists)
                throw new KeyNotFoundException("Miembro no encontrado");

            await _memberRepository.DeleteAsync(id);
        }
    }
}