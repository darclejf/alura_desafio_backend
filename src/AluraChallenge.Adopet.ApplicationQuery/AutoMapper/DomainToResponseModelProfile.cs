﻿using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain;
using AutoMapper;

namespace AluraChallenge.Adopet.ApplicationQuery.AutoMapper
{
    public class DomainToResponseModelProfile : Profile
    {
        public DomainToResponseModelProfile()
        {
            CreateMap<Tutor, PersonListItemResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address));

            CreateMap<Tutor, TutorResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address));

            CreateMap<Pet, PetListItemResponse>();

            CreateMap<Pet, PetResponse>();

            CreateMap<Domain.Adopet, AdopetResponse>();

            CreateMap<City, CityResponse>();
            CreateMap<User, UserResponse>();

            CreateMap<Shelter, PersonListItemResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Address));
            CreateMap<Shelter, ShelterResponse>();
        }
    }
}
