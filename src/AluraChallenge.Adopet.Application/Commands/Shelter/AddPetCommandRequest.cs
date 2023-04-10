using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class AddPetCommandRequest : IRequest<PetResponse>
    {
        public AddPetRequest Request { get; set; }

        public AddPetCommandRequest(AddPetRequest request)
        {
            Request = request;
        }
    }
}
