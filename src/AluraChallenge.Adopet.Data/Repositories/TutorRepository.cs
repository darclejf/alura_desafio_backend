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

        /// <summary>
        /// Método para criar um novo Tutor com seu usuário vinculado
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns><see cref="Tutor"/></returns>
        public async Task<Tutor> AddAsync(Tutor tutor)
        {
            await _context.AddAsync(tutor);
            return tutor;
        }

        /// <summary>
        /// Método para excluir um Tutor e seu Usuário
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Tutor tutor)
        {
            _context.Remove(tutor);
        }

        /// <summary>
        /// Método para retornar uma entidade Tutor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Tutor"/></returns>
        public async Task<Tutor?> GetByIdAsync(Guid id)
        {
            return await _context
                            .Tutors
                            .Include(t => t.City)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Método para atualizar um Tutor
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Tutor tutor)
        {
            _context.Update(tutor);
        }

        public async Task<Tutor?> GetByEmailAsync(string email)
        {
            return await _context
                            .Tutors
                            .FirstOrDefaultAsync(x => x.Email.Address == email);
        }
    }
}
