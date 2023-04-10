using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.Data.Repositories
{
    public class ShelterRepository : BaseRepository<Shelter>, IShelterRepository
    {
        public ShelterRepository(AdopetDbContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<Shelter?> GetByEmailAsync(string email)
        {
            return await _context
                            .Shelters
                            .FirstOrDefaultAsync(e => e.Email.Address == email);
        }

        public async Task<Shelter?> GetByIdAsync(Guid id)
        {
            return await _context
                            .Shelters
                            .Include(e => e.City)
                            .Include(e => e.Pets)
                            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Pet?> GetPetByIdAsync(Guid petId)
        {
            return await _context
                            .Pets
                            .Include(e => e.Shelter)
                            .FirstOrDefaultAsync(e => e.Id == petId);
        }

    }
}
