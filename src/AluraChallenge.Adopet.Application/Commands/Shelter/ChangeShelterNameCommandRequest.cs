using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterNameCommandRequest : IRequest<ShelterResponse>
    {
        public Guid Id { get; set; }
        public NameRequest Request { get; set; }

        public ChangeShelterNameCommandRequest(Guid id, NameRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
