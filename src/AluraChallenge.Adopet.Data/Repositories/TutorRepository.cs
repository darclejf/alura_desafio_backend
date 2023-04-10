using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.Data.Repositories
{
    /// <summary>
    /// Classe que implementa a interface repositório para manter uma entidade do tipo Tutor 
    /// </summary>
    public class TutorRepository : BaseRepository<Tutor>, ITutorRepository
    {
        public TutorRepository(AdopetDbContext context, IMediator mediator) : base(context, mediator)
        { }

        public async Task<Tutor?> GetByIdAsync(Guid id)
        {
            return await _context
                            .Tutors
                            .Include(t => t.City)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tutor?> GetByEmailAsync(string email)
        {
            return await _context
                            .Tutors
                            .FirstOrDefaultAsync(x => x.Email.Address == email);
        }     
    }
}
