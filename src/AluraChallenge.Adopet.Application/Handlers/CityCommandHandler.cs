using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class CityCommandHandler :
                            IRequestHandler<CreateCityCommandRequest, CityResponse>,
                            IRequestHandler<DeleteCityCommandRequest, bool>
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityCommandHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _repository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityResponse> Handle(CreateCityCommandRequest command, CancellationToken cancellationToken)
        {
            var city = City.Create(
                            command.Name,
                            command.UF);

            await _repository.AddAsync(city);
            await _repository.SaveAsync();

            return _mapper.Map<CityResponse>(city);
        }

        public async Task<bool> Handle(DeleteCityCommandRequest command, CancellationToken cancellationToken)
        {
            var city = await _repository.GetByIdAsync(command.Id);
            if (city == null)
                return true;
            await _repository.DeleteAsync(city);
            await _repository.SaveAsync();
            return true;
        }
    }
}
