using AluraChallenge.Adopet.Application.Responses;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class CreateCityCommandRequest : IRequest<CreateCityResponse>
    {
        public string Name { get; set; }
        public string UF { get; set; }
    }
}
