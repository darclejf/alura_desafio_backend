using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorPhoneCommandRequest : IRequest<TutorResponse>
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
