using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Domain;
using AutoMapper;

namespace AluraChallenge.Adopet.Application.AutoMapper
{
    public class DomainToResponseModelProfile : Profile
    {
        public DomainToResponseModelProfile()
        {
            CreateMap<Tutor, TutorResponse>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address))
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.City != null ? s.City.Name : ""));

            CreateMap<Pet, PetResponse>();

            CreateMap<Domain.Adopet, AdopetResponse>();
            
            CreateMap<City, CityResponse>();

            CreateMap<Shelter, ShelterResponse>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address))
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.City != null ? s.City.Name : ""));
        }
    }
}
