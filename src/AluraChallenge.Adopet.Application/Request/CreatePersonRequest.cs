namespace AluraChallenge.Adopet.Application.Request
{
    public class CreatePersonRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }
    }
}
