namespace AluraChallenge.Adopet.Application.Responses
{
    public class ChangeProfilePropertiesResponse
    {
        public Guid Id { get; set; }
        public string? OldName { get; set; }
        public string? OldPhone { get; set; }
        public string? NewName { get; set; }
        public string? NewPhone { get; set; }
        public string? OldCity { get; set; }
        public string? NewCity { get; set; }
    }
}
