using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteTutorCommandRequest : IRequest<bool>
    {
        public Guid TutorId { get; set; }
    }
}
