using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class AdopetPetCommandRequest : IRequest<AdopetResponse>
    {
        public Guid TutorId { get; set; }
        public Guid PetId { get; set; }
    }
}
