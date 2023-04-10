using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterPropertiesCommandRequest : IRequest<ShelterResponse>
    {
        public Guid Id { get; set; }
        public UpdatePersonRequest Request { get; set; }

        public ChangeShelterPropertiesCommandRequest(Guid id, UpdatePersonRequest updatePersonRequest)
        {
            Id = id;
            Request = updatePersonRequest;
        }
    }
}
