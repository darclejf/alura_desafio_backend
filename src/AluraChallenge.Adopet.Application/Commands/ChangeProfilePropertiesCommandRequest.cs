using AluraChallenge.Adopet.Application.Responses;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeProfilePropertiesCommandRequest : IRequest<ChangeProfilePropertiesResponse>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? UrlImage { get; set; }
        public Guid? CityId { get; set; }
        public string? CityName { get; set; }
        public string? UF { get; set; }
    }
}
