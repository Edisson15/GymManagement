namespace GymManagement.Domain.Entities
{
    public class Trainer : AuditBase
    {
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;

        public ICollection<GymClass> GymClasses { get; set; } = new List<GymClass>();
    }
}