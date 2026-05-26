using AutoMapper;
using GymManagement.Domain.Entities;
using GymManagement.API.DTOs.Request;
using GymManagement.API.DTOs.Response;

namespace GymManagement.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Member
            CreateMap<Member, MemberResponseDTO>();
            CreateMap<MemberRequestDTO, Member>();

            // Membership
            CreateMap<Membership, MembershipResponseDTO>();
            CreateMap<MembershipRequestDTO, Membership>();

            // Trainer
            CreateMap<Trainer, TrainerResponseDTO>();
            CreateMap<TrainerRequestDTO, Trainer>();

            // GymClass
            CreateMap<GymClass, GymClassResponseDTO>();
            CreateMap<GymClassRequestDTO, GymClass>();

            // Enrollment
            CreateMap<Enrollment, EnrollmentResponseDTO>();
            CreateMap<EnrollmentRequestDTO, Enrollment>();
        }
    }
}