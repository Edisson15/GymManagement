using GymManagement.Domain.Enums;

namespace GymManagement.API.DTOs.Request
{
    public class MemberRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int MembershipId { get; set; }
    }
}