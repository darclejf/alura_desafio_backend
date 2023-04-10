using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.Data.Repositories
{
    public class AdopetRepository : BaseRepository<Domain.Adopet>, IAdopetRepository
    {
        public AdopetRepository(AdopetDbContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<Domain.Adopet?> GetByIdAsync(Guid id)
        {
            return await _context
                        .Adopets
                        .Include(e => e.Tutor)
                        .Include(e => e.Pet)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Domain.Adopet?> GetByPetIdAsync(Guid petId)
        {
            return await _context
                        .Adopets
                        .Include(e => e.Tutor)
                        .Include(e => e.Pet)
                        .FirstOrDefaultAsync(e => e.PetId == petId);
        }
    }
}
