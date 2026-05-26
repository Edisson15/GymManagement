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
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public MemberController(
            IMemberService memberService,
            IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var members = await _memberService.GetAllAsync();

            var response = _mapper.Map<
                IEnumerable<MemberResponseDTO>
            >(members);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);

            if (member == null)
                return NotFound();

            var response = _mapper.Map<
                MemberResponseDTO
            >(member);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            MemberRequestDTO dto)
        {
            var member = _mapper.Map<Member>(dto);

            var created = await _memberService
                .CreateAsync(member);

            var response = _mapper.Map<
                MemberResponseDTO
            >(created);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            MemberRequestDTO dto)
        {
            var member = _mapper.Map<Member>(dto);

            await _memberService.UpdateAsync(
                id,
                member
            );

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _memberService.DeleteAsync(id);

            return NoContent();
        }
    }
}