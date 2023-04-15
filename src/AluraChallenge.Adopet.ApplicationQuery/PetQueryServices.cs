using AluraChallenge.Adopet.ApplicationQuery.Response;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Domain;
using AutoMapper;

namespace AluraChallenge.Adopet.ApplicationQuery
{
    public class PetQueryServices : BaseQueryServices<Pet, PetListItemResponse, PetQueryResponse>
    {
        public PetQueryServices(AdopetDbContext context, IMapper mapper) : base(context, mapper, context.Pets)
        {
        }
    }
}
