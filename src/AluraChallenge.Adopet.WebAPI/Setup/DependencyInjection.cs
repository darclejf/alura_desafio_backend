using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Handlers;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.Authentication.Interfaces;
using AluraChallenge.Adopet.Authentication.Services;
using AluraChallenge.Adopet.Data;
using AluraChallenge.Adopet.Data.Repositories;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.DomainEventsHandlers;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AluraChallenge.Adopet.WebAPI.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationQuery.AutoMapper.DomainToResponseModelProfile));
            services.AddAutoMapper(typeof(Application.AutoMapper.DomainToResponseModelProfile));

            services.AddScoped<AdopetDbContext>();

            services.RegisterRepositories();
            services.RegisterQueryServices();
            services.RegisterTutorCommands();
            services.RegisterShelterCommands();
            services.RegisterCityCommands();
            services.RegisterAdopetTutorCommands();
            services.RegisterNotificationsHandlers();
        }

        public static void RegisterAuthenticationServices(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("akldaklds#45lsadjdsa%67ajkdsakjdsajkasdksakdsajlaskhldakhskajhda"))
                };
            });
            services.AddScoped<IUserServices, UserServices>();
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
            services.AddScoped<IRequestHandler<CreateCityCommandRequest, ApplicationResponse<CityResponse>>, CityCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCityCommandRequest, ApplicationResponse<bool>>, CityCommandHandler>();
        }

        private static void RegisterTutorCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateTutorCommandRequest, ApplicationResponse<TutorResponse>>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorPropertiesCommandRequest, ApplicationResponse<TutorResponse>>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorAboutCommandRequest, ApplicationResponse<TutorResponse>>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorAddressCommandRequest, ApplicationResponse<TutorResponse>>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorNameCommandRequest, ApplicationResponse<TutorResponse>>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorPhoneCommandRequest, ApplicationResponse<TutorResponse>>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeTutorUrlImageCommandRequest, ApplicationResponse<TutorResponse>>, TutorCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTutorCommandRequest, ApplicationResponse<bool>>, TutorCommandHandler>();
        }

        private static void RegisterShelterCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateShelterCommandRequest, ApplicationResponse<ShelterResponse>>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterPropertiesCommandRequest, ApplicationResponse<ShelterResponse>>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterAddressCommandRequest, ApplicationResponse<ShelterResponse>>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterNameCommandRequest, ApplicationResponse<ShelterResponse>>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterPhoneCommandRequest, ApplicationResponse<ShelterResponse>>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<ChangeShelterUrlImageCommandRequest, ApplicationResponse<ShelterResponse>>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteShelterCommandRequest, ApplicationResponse<bool>>, ShelterCommandHandler>();
            services.AddScoped<IRequestHandler<AddPetCommandRequest, ApplicationResponse<PetResponse>>, ShelterCommandHandler>();
        }

        private static void RegisterAdopetTutorCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdopetPetCommandRequest, ApplicationResponse<AdopetResponse>>, AdopetCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAdopetCommandRequest, ApplicationResponse<bool>>, AdopetCommandHandler>();
        }

        private static void RegisterNotificationsHandlers(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<CreateEntityDomainEvent<Tutor>>, ValidateEmailExistsDomainEventHandler>();
            services.AddScoped<INotificationHandler<CreateEntityDomainEvent<Shelter>>, ValidateEmailExistsDomainEventHandler>();
            services.AddScoped<INotificationHandler<ChangeCityAddressDomainEvent>, ValidateCityExistsDomainEventHandler>();
        }
    }
}