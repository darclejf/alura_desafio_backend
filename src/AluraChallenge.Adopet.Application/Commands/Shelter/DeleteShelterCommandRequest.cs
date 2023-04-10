using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteShelterCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteShelterCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
