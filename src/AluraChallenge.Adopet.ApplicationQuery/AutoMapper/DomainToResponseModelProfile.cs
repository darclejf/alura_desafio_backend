using AluraChallenge.Adopet.ApplicationQuery.Response;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain;
using AutoMapper;

namespace AluraChallenge.Adopet.ApplicationQuery.AutoMapper
{
    public class DomainToResponseModelProfile : Profile
    {
        public DomainToResponseModelProfile()
        {
            //CreateMap<Pet, PetListItemResponse>();

            CreateMap<Pet, PetQueryResponse>();

            CreateMap<Tutor, PersonListItemResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address));

            CreateMap<Shelter, PersonListItemResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address));

            CreateMap<Tutor, TutorQueryResponse>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address))
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.City != null ? s.City.Name : ""));

            CreateMap<Pet, PetQueryResponse>();

            //CreateMap<City, CityResponse>();

            CreateMap<Shelter, ShelterQueryResponse>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address))
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.City != null ? s.City.Name : ""));
        }
    }
}
