using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorPropertiesCommandRequest : IRequest<TutorResponse>
    {
        public Guid Id { get; set; }
        public UpdatePersonRequest Request { get; set; }

        public ChangeTutorPropertiesCommandRequest(Guid id, UpdatePersonRequest updatePersonRequest)
        {
            Id = id;
            Request = updatePersonRequest;
        }
    }
}
