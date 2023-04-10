namespace AluraChallenge.Adopet.Core.Models
{
    [Serializable]
    public class TutorResponse : BaseEntityResponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
    }
}
