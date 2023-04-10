using AluraChallenge.Adopet.Application.Request;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterPasswordCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public PasswordRequest Request { get; set; }
        
        public ChangeShelterPasswordCommandRequest(Guid id, PasswordRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
