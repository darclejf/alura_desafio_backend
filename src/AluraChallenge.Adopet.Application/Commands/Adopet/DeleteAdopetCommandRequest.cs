using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteAdopetCommandRequest : IRequest<ApplicationResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
