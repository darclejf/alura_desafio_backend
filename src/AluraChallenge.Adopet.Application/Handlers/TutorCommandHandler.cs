using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Responses;
using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class TutorCommandHandler :
                        IRequestHandler<CreateTutorCommandRequest, CreateTutorResponse>,
                        IRequestHandler<ChangeProfilePropertiesCommandRequest, ChangeProfilePropertiesResponse>,
                        IRequestHandler<ChangeTutorPasswordCommandRequest, bool>,
                        IRequestHandler<DeleteTutorCommandRequest, bool>
    {
        private readonly ITutorRepository _repository;
        private readonly ICityRepository _cityRepository;

        public TutorCommandHandler(ITutorRepository repository, ICityRepository cityRepository)
        {
            _repository = repository;
            _cityRepository = cityRepository;
        }

        public async Task<CreateTutorResponse> Handle(CreateTutorCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = Tutor.Create(command.Name, 
                                    command.Email, 
                                    command.Password, 
                                    command.ConfirmPassword,
                                    command.Phone);

            await _repository.AddAsync(tutor);
            await _repository.SaveAsync();

            return new CreateTutorResponse() { Id = tutor.Id };
        }

        public async Task<bool> Handle(ChangeTutorPasswordCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.TutorId);
            tutor.ChangePassword(command.Password, command.ConfirmPassword);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> Handle(DeleteTutorCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.TutorId);
            await _repository.DeleteAsync(tutor);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<ChangeProfilePropertiesResponse> Handle(ChangeProfilePropertiesCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            var response = new ChangeProfilePropertiesResponse
            {
                Id = tutor.Id,
                OldPhone = tutor.Phone,
                OldName = tutor.Name,
                OldCity = tutor.City?.Name
            };

            if (!string.IsNullOrEmpty(command.Name))
                tutor.ChangeName(command.Name);
            if (!string.IsNullOrEmpty(command.UrlImage))
                tutor.ChangeUrlImage(command.UrlImage);

            tutor.ChangePhone(command.Phone);
            
            var city = await GetCityById(command.CityId, command.CityName, command.UF);
            tutor.ChangeCity(city);
            response.NewCity = tutor.City?.Name;

            await _repository.SaveAsync();

            response.NewName = tutor.Name;
            response.NewPhone = tutor.Phone;

            return response;
        }

        private async Task<Tutor> GetTutorByIdAsync(Guid id)
        {
            var tutor = await _repository.GetByIdAsync(id);
            if (tutor == null)
                throw new EntityNotFoundException();

            return tutor;
        }

        //TODO verificar/refatorar esse metodo com servicos de dominio
        private async Task<City> GetCityById(Guid? id, string? name, string? uf)
        {
            if (id.HasValue)
            {
                var city = await _cityRepository.GetByIdAsync(id.Value);
                if (city == null)
                    return City.Create(id, name, uf);
                return city;
            }
            else
                return City.Create(id, name, uf);
        }
    }
}
