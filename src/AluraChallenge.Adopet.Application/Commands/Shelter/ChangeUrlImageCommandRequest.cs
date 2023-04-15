using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterUrlImageCommandRequest : IRequest<ApplicationResponse<ShelterResponse>>
    {
        public Guid Id { get; set; }
        public UrlImageRequest Request { get; set; }

        public ChangeShelterUrlImageCommandRequest(Guid id, UrlImageRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
