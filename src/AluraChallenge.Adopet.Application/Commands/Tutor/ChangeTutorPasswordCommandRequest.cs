using AluraChallenge.Adopet.Application.Request;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorPasswordCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public PasswordRequest Request { get; set; }

        public ChangeTutorPasswordCommandRequest(Guid id, PasswordRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
