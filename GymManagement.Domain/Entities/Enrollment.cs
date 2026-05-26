namespace GymManagement.Domain.Entities
{
    public class Enrollment : AuditBase
    {
        public int MemberId { get; set; }
        public int GymClassId { get; set; }

        // Navigation
        public Member Member { get; set; } = null!;
        public GymClass GymClass { get; set; } = null!;
    }
}