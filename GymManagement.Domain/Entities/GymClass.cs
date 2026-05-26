using GymManagement.Domain.Enums;

namespace GymManagement.Domain.Entities
{
    public class GymClass : AuditBase
    {
        public string Name { get; set; } = string.Empty;

        // Relación con Trainer (1:N)
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;

        public DateTime Schedule { get; set; }
        public int Capacity { get; set; }

        public ClassStatus Status { get; set; } = ClassStatus.Scheduled;

        // Relación N:M
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}