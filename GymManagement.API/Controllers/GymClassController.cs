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
    public class GymClassController : ControllerBase
    {
        private readonly IGymClassService _service;
        private readonly IMapper _mapper;

        public GymClassController(
            IGymClassService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var classes = await _service.GetAllAsync();

            return Ok(
                _mapper.Map<IEnumerable<GymClassResponseDTO>>(classes)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gymClass = await _service.GetByIdAsync(id);

            if (gymClass == null)
                return NotFound();

            return Ok(
                _mapper.Map<GymClassResponseDTO>(gymClass)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create(GymClassRequestDTO dto)
        {
            var gymClass = _mapper.Map<GymClass>(dto);

            var created = await _service.CreateAsync(gymClass);

            return Ok(
                _mapper.Map<GymClassResponseDTO>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            GymClassRequestDTO dto)
        {
            var gymClass = _mapper.Map<GymClass>(dto);

            await _service.UpdateAsync(id, gymClass);

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