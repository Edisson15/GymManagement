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
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _service;
        private readonly IMapper _mapper;

        public TrainerController(
            ITrainerService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _service.GetAllAsync();

            return Ok(
                _mapper.Map<IEnumerable<TrainerResponseDTO>>(trainers)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trainer = await _service.GetByIdAsync(id);

            if (trainer == null)
                return NotFound();

            return Ok(
                _mapper.Map<TrainerResponseDTO>(trainer)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainerRequestDTO dto)
        {
            var trainer = _mapper.Map<Trainer>(dto);

            var created = await _service.CreateAsync(trainer);

            return Ok(
                _mapper.Map<TrainerResponseDTO>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            TrainerRequestDTO dto)
        {
            var trainer = _mapper.Map<Trainer>(dto);

            await _service.UpdateAsync(id, trainer);

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