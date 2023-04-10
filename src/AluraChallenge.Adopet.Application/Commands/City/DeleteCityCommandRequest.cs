using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteCityCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
