using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class CityCommandHandler :
                            IRequestHandler<CreateCityCommandRequest, ApplicationResponse<CityResponse>>,
                            IRequestHandler<DeleteCityCommandRequest, ApplicationResponse<bool>>
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityCommandHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _repository = cityRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<CityResponse>> Handle(CreateCityCommandRequest command, CancellationToken cancellationToken)
        {
            var city = City.Create(
                            command.Name,
                            command.UF);

            await _repository.AddAsync(city);
            await _repository.SaveAsync();
            return new ApplicationResponse<CityResponse> { IsValid = true, Result = _mapper.Map<CityResponse>(city) };
        }

        public async Task<ApplicationResponse<bool>> Handle(DeleteCityCommandRequest command, CancellationToken cancellationToken)
        {
            //var city = await _repository.GetByIdAsync(command.Id);
            //if (city == null)
            //    return true;
            //await _repository.DeleteAsync(city);
            //await _repository.SaveAsync();
            //return true;
            return null;
        }
    }
}
