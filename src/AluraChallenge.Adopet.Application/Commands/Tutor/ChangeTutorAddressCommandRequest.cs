using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorAddressCommandRequest : IRequest<TutorResponse>
    {
        public Guid Id { get; set; }
        public AddressRequest Request { get; set; }

        public ChangeTutorAddressCommandRequest(Guid id, AddressRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
