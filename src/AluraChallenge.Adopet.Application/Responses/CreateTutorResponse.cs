using AluraChallenge.Adopet.Core.ValueObjects;

namespace AluraChallenge.Adopet.Application.Responses
{
    public class CreateTutorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
    }
}
