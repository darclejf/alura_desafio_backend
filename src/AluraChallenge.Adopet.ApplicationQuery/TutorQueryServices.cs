using AluraChallenge.Adopet.ApplicationQuery.ViewModels;
using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.ApplicationQuery
{
    public class TutorQueryServices
    {
        private readonly AdopetDbContext _context;
        private readonly IMapper _mapper;

        public TutorQueryServices(AdopetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginationListViewModel<TutorListItemViewModel>> GetAsync(int? page = null, int? total = null)
        {
            var query = _context
                            .Tutors
                            .AsNoTracking()
                            .Select(t => _mapper.Map<TutorListItemViewModel>(t));

            if (page.HasValue)
                query = query.Skip(page.Value);

            if (total.HasValue)
                query = query.Take(total.Value);

            return new PaginationListViewModel<TutorListItemViewModel>() { Page = page, Total = total, Items = query.ToList() };
        }

        public async Task<TutorViewModel> GetAsync(Guid id)
        {
            var tutor = _context
                            .Tutors
                            .AsNoTracking()
                            .FirstOrDefault(q => q.Id == id);
            
            if (tutor == null)
                throw new EntityNotFoundException();

            return _mapper.Map<TutorViewModel>(tutor);
        }
    }
}