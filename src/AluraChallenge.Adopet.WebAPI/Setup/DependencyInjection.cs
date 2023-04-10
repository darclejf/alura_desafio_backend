using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Handlers;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.ApplicationQuery.AutoMapper;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Data.Repositories;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.DomainEventsHandlers;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.WebAPI.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToResponseModelProfile));

            services.AddScoped<AdopetDbContext>();

            services.RegisterRepositories();
            services.RegisterQueryServices();
            services.RegisterTutorCommands();
            services.RegisterShelterCommands();
            services.RegisterCityCommands();
            services.RegisterAdopetTutorCommands();
            services.RegisterNotificationsHandlers();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITutorRepository, TutorRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IShelterRepository, ShelterRepository>();
            services.AddScoped<IAdopetRepository, AdopetRepository>();
        }

        private static void RegisterQueryServices(this IServiceCollection services)
        {
            services.AddScoped<TutorQueryServices>();
            services.AddScoped<ShelterQueryServices>();
            services.AddScoped<PetQueryServices>();
        }

        private static void RegisterCityCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateCityCommandRequest, CityResponse>, CityCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCityCommandRequest, bool>, CityCommandHandler>();
        }

        private static void RegisterTutorCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateTutorCommandRequest, TutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorPropertiesCommandRequest, TutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorAboutCommandRequest, TutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorAddressCommandRequest, TutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorNameCommandRequest, TutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorPhoneCommandRequest, TutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorUrlImageCommandRequest, TutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorPasswordCommandRequest, bool>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTutorCommandRequest, bool>, TutorCommandHandler>();
        }

        private static void RegisterShelterCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateShelterCommandRequest, ShelterResponse>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterPropertiesCommandRequest, ShelterResponse>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterAddressCommandRequest, ShelterResponse>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterNameCommandRequest, ShelterResponse>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterPhoneCommandRequest, ShelterResponse>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterUrlImageCommandRequest, ShelterResponse>, ShelterCommandHandler>();
            //services.AddScoped<IRequestHandler<ChangeShelterPasswordCommandRequest, bool>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteShelterCommandRequest, bool>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<AddPetCommandRequest, PetResponse>, ShelterCommandHandler>();
        }

        private static void RegisterAdopetTutorCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdopetPetCommandRequest, AdopetResponse>, AdopetCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAdopetCommandRequest, bool>, AdopetCommandHandler>();
        }

        private static void RegisterNotificationsHandlers(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<CreateEntityDomainEvent<Tutor>>, ValidateEmailExistsDomainEventHandler>();
            services.AddScoped<INotificationHandler<CreateEntityDomainEvent<Shelter>>, ValidateEmailExistsDomainEventHandler>();
            services.AddScoped<INotificationHandler<ChangeCityAddressDomainEvent>, ValidateCityExistsDomainEventHandler>();
        }
    }
}