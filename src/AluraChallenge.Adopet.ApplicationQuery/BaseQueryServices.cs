using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Domain.Abstraction;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.ApplicationQuery
{
    public abstract class BaseQueryServices<T, R, X> : IDisposable 
                                                        where T : Entity 
                                                        where R : BaseEntityResponse
                                                        where X : BaseEntityResponse
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly AdopetDbContext _context;
        protected readonly IMapper _mapper;

        public BaseQueryServices(AdopetDbContext context, IMapper mapper, DbSet<T> dbSet)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = dbSet;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual async Task<PaginationListResponse<R>> GetAsync(int? page = null, int? pageSize = null)
        {
            var query = _dbSet
                            .AsNoTracking()
                            .Select(t => _mapper.Map<R>(t));

            if (page.HasValue)
                query = query.Skip(page.Value);

            if (pageSize.HasValue)
                query = query.Take(pageSize.Value);

            return new PaginationListResponse<R>() { 
                Page = page, 
                PageSize = pageSize, 
                Items = await query.ToListAsync() 
            };
        }

        public virtual async Task<X> GetAsync(Guid id)
        {
            var entity = await  _dbSet
                            .AsNoTracking()
                            .FirstOrDefaultAsync(q => q.Id == id);

            return entity switch
            {
                null => throw new EntityNotFoundException(),
                _ => _mapper.Map<X>(entity)
            };
        }
    }
}
