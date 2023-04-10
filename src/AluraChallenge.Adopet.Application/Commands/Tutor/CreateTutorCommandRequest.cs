using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class CreateTutorCommandRequest : IRequest<TutorResponse>
    {
        public CreatePersonRequest Request { get; set; }

        public CreateTutorCommandRequest(CreatePersonRequest request)
        {
            Request = request;
        }
    }
}
