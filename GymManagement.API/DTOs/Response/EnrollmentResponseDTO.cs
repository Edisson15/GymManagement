namespace GymManagement.API.DTOs.Response
{
    public class EnrollmentResponseDTO
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public int GymClassId { get; set; }
        public string GymClassName { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
    }
}