namespace GymManagement.API.DTOs.Response
{
    public class MembershipResponseDTO
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}