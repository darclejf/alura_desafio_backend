using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class AdopetPetCommandRequest : IRequest<ApplicationResponse<AdopetResponse>>
    {
        public Guid TutorId { get; set; }
        public Guid PetId { get; set; }
    }
}
