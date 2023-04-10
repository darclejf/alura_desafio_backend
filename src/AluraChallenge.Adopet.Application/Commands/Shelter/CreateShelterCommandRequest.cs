using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class CreateShelterCommandRequest : IRequest<ShelterResponse>
    {
        public CreatePersonRequest Request { get; set; }

        public CreateShelterCommandRequest(CreatePersonRequest request)
        {
            Request = request;
        }
    }
}
