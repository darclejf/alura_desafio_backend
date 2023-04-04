using AluraChallenge.Adopet.Application.Responses;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class CreateTutorCommandRequest : IRequest<CreateTutorResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
