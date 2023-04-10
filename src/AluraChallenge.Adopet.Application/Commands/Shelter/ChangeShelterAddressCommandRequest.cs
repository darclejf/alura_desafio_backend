using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterAddressCommandRequest : IRequest<ShelterResponse>
    {
        public Guid Id { get; set; }
        public AddressRequest Request { get; set; }

        public ChangeShelterAddressCommandRequest(Guid id, AddressRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
