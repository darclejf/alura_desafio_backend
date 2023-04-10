using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteTutorCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTutorCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
