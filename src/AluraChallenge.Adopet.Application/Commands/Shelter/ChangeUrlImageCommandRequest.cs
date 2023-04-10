using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Models;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterUrlImageCommandRequest : IRequest<ShelterResponse>
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
