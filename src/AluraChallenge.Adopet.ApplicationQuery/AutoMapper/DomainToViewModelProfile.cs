using AluraChallenge.Adopet.ApplicationQuery.ViewModels;
using AluraChallenge.Adopet.Domain;
using AutoMapper;

namespace AluraChallenge.Adopet.ApplicationQuery.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Tutor, TutorListItemViewModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address));

            CreateMap<Tutor, TutorViewModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address));
        }
    }
}
