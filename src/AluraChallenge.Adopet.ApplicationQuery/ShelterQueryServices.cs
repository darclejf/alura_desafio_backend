using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Domain;
using AutoMapper;

namespace AluraChallenge.Adopet.ApplicationQuery
{
    public class ShelterQueryServices : BaseQueryServices<Shelter, PersonListItemResponse, TutorResponse>
    {
        public ShelterQueryServices(AdopetDbContext context, IMapper mapper)
                        : base(context, mapper, context.Shelters)
        { }
    }
}