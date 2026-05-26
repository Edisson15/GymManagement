namespace GymManagement.API.DTOs.Request
{
    public class GymClassRequestDTO
    {
        public string Name { get; set; } = string.Empty;

        public int TrainerId { get; set; }

        public DateTime Schedule { get; set; }

        public int Capacity { get; set; }

        public int Status { get; set; }
    }
}