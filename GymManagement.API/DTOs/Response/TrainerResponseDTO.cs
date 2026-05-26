namespace GymManagement.API.DTOs.Response
{
    public class TrainerResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Specialty { get; set; } = string.Empty;
    }
}