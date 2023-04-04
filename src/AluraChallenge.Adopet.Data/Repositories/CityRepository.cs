using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AdopetDbContext context, IMediator mediator) : base(context,mediator)
        { }
 
        public async Task<City> AddAsync(City entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(City entity)
        {
            _context.Remove(entity);
        }

        public async Task<City?> GetByIdAsync(Guid id)
        {
            return await _context
                .Cities
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
