using AluraChallenge.Adopet.Application.Response;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class CreateCityCommandRequest : IRequest<ApplicationResponse<CityResponse>>
    {
        public string Name { get; set; }
        public string UF { get; set; }
    }
}
