using AluraChallenge.Adopet.ApplicationQuery.Response;
using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.ApplicationQuery
{
    public class ShelterQueryServices : BaseQueryServices<Shelter, PersonListItemResponse, ShelterQueryResponse>
    {
        public ShelterQueryServices(AdopetDbContext context, IMapper mapper)
                        : base(context, mapper, context.Shelters)
        { }

        public override async Task<ShelterQueryResponse> GetAsync(Guid id)
        {
            var entity = await _dbSet
                                .Include(x => x.City)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(q => q.Id == id);

            return entity switch
            {
                null => throw new EntityNotFoundException(),
                _ => _mapper.Map<ShelterQueryResponse>(entity)
            };
        }
    }
}