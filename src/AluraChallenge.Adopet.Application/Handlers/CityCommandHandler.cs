using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Responses;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class CityCommandHandler :
                            IRequestHandler<CreateCityCommandRequest, CreateCityResponse>,
                            IRequestHandler<DeleteCityCommandRequest, bool>
    {
        private readonly ICityRepository _repository;

        public CityCommandHandler(ICityRepository cityRepository)
        {
            _repository = cityRepository;
        }

        public async Task<CreateCityResponse> Handle(CreateCityCommandRequest command, CancellationToken cancellationToken)
        {
            var city = City.Create(
                            command.Name,
                            command.UF);

            await _repository.AddAsync(city);
            await _repository.SaveAsync();

            return new CreateCityResponse {  
                    Id = city.Id, 
                    UF = city.UF, 
                    Name = city.Name };
        }

        public async Task<bool> Handle(DeleteCityCommandRequest command, CancellationToken cancellationToken)
        {
            var city = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(city);
            await _repository.SaveAsync();
            return true;

        }
    }
}
