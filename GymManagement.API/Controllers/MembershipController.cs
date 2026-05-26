using AutoMapper;
using GymManagement.API.DTOs.Request;
using GymManagement.API.DTOs.Response;
using GymManagement.Domain.Entities;
using GymManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _service;
        private readonly IMapper _mapper;

        public MembershipController(
            IMembershipService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var memberships = await _service.GetAllAsync();

            return Ok(
                _mapper.Map<IEnumerable<MembershipResponseDTO>>(memberships)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var membership = await _service.GetByIdAsync(id);

            if (membership == null)
                return NotFound();

            return Ok(
                _mapper.Map<MembershipResponseDTO>(membership)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            MembershipRequestDTO dto)
        {
            var membership = _mapper.Map<Membership>(dto);

            var created = await _service.CreateAsync(membership);

            return Ok(
                _mapper.Map<MembershipResponseDTO>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            MembershipRequestDTO dto)
        {
            var membership = _mapper.Map<Membership>(dto);

            await _service.UpdateAsync(id, membership);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}