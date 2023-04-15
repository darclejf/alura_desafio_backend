using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorUrlImageCommandRequest : IRequest<ApplicationResponse<TutorResponse>>
    {
        public Guid Id { get; set; }
        public UrlImageRequest Request { get; set; }

        public ChangeTutorUrlImageCommandRequest(Guid id, UrlImageRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
