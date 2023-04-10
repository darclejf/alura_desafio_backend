using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteAdopetCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
