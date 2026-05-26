namespace GymManagement.API.DTOs.Request
{
    public class MembershipRequestDTO
    {
        public int Type { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}