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
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;
        private readonly IMapper _mapper;

        public EnrollmentController(
            IEnrollmentService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _service.GetAllAsync();

            return Ok(
                _mapper.Map<IEnumerable<EnrollmentResponseDTO>>(enrollments)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enrollment = await _service.GetByIdAsync(id);

            if (enrollment == null)
                return NotFound();

            return Ok(
                _mapper.Map<EnrollmentResponseDTO>(enrollment)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            EnrollmentRequestDTO dto)
        {
            var enrollment = _mapper.Map<Enrollment>(dto);

            var created = await _service.CreateAsync(enrollment);

            return Ok(
                _mapper.Map<EnrollmentResponseDTO>(created)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}