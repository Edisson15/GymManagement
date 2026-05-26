using GymManagement.Domain.Enums;

namespace GymManagement.Domain.Entities
{
    public class Member : AuditBase
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relación N:1 con Membership
        public int MembershipId { get; set; }
        public Membership Membership { get; set; } = null!;

        // Relación N:M (se completará después)
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}