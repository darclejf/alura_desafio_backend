using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorAboutCommandRequest : IRequest<ApplicationResponse<TutorResponse>>
    {
        public Guid Id { get; set; }
        public AboutRequest Request { get; set; }

        public ChangeTutorAboutCommandRequest(Guid id, AboutRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
