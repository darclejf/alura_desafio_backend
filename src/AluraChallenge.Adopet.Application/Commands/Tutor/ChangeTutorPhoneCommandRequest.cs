using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorPhoneCommandRequest : IRequest<ApplicationResponse<TutorResponse>>
    {
        public Guid Id { get; set; }
        public PhoneRequest Request { get; set; }

        public ChangeTutorPhoneCommandRequest(Guid id, PhoneRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
