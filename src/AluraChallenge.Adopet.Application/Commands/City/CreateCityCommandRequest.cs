using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class CreateCityCommandRequest : IRequest<CityResponse>
    {
        public string Name { get; set; }
        public string UF { get; set; }
    }
}
