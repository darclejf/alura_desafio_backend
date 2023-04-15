using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterPhoneCommandRequest : IRequest<ApplicationResponse<ShelterResponse>>
    {
        public Guid Id { get; set; }
        public PhoneRequest Request { get; set; }

        public ChangeShelterPhoneCommandRequest(Guid id, PhoneRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
