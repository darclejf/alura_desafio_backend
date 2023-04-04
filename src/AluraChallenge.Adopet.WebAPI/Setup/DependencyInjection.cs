using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Handlers;
using AluraChallenge.Adopet.Application.Responses;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.ApplicationQuery.AutoMapper;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Data.Repositories;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.WebAPI.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelProfile));

            services.AddScoped<ITutorRepository, TutorRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<TutorQueryServices>();
            services.AddScoped<AdopetDbContext>();

            services.AddScoped<IRequestHandler<CreateTutorCommandRequest, CreateTutorResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeProfilePropertiesCommandRequest, ChangeProfilePropertiesResponse>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorPasswordCommandRequest, bool>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTutorCommandRequest, bool>, TutorCommandHandler>();

            services.AddScoped<IRequestHandler<CreateCityCommandRequest, CreateCityResponse>, CityCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCityCommandRequest, bool>, CityCommandHandler>();

            services.AddScoped<INotificationHandler<CreateTutorDomainEvent>, ValidateEmailExistsDomainEventHandler>();
            services.AddScoped<INotificationHandler<CreateCityDomainEvent>, ValidateCityExistsDomainEventHandler>();
        }
    }
}