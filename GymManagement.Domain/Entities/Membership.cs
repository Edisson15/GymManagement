using GymManagement.Domain.Enums;

namespace GymManagement.Domain.Entities
{
    public class Membership : AuditBase
    {
        public MembershipType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

      
        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}