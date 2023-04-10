using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Domain;
using AutoMapper;

namespace AluraChallenge.Adopet.ApplicationQuery
{
    public class TutorQueryServices : BaseQueryServices<Tutor, PersonListItemResponse, TutorResponse>
    {
        public TutorQueryServices(AdopetDbContext context, IMapper mapper) 
                        : base (context, mapper, context.Tutors)
        { }
    }
}