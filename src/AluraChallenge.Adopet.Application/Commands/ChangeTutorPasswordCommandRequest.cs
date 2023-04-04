using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorPasswordCommandRequest : IRequest<bool>
    {
        public Guid TutorId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
