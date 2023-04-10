using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class TutorCommandHandler : //TODO refatorar para um PersonHandler??
                        IRequestHandler<CreateTutorCommandRequest, TutorResponse>,
                        IRequestHandler<ChangeTutorPropertiesCommandRequest, TutorResponse>,
                        IRequestHandler<ChangeTutorAboutCommandRequest, TutorResponse>,
                        IRequestHandler<ChangeTutorAddressCommandRequest, TutorResponse>,
                        IRequestHandler<ChangeTutorNameCommandRequest, TutorResponse>,
                        IRequestHandler<ChangeTutorPhoneCommandRequest, TutorResponse>,
                        IRequestHandler<ChangeTutorUrlImageCommandRequest, TutorResponse>,
                        IRequestHandler<ChangeTutorPasswordCommandRequest, bool>,
                        IRequestHandler<DeleteTutorCommandRequest, bool> 
    {
        private readonly ITutorRepository _repository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public TutorCommandHandler(ITutorRepository repository, ICityRepository cityRepository, IMapper mapper)
        {
            _repository = repository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<TutorResponse> Handle(CreateTutorCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = Tutor.Create(command.Request.Name, 
                                    command.Request.Email, 
                                    command.Request.Password, 
                                    command.Request.ConfirmPassword,
                                    command.Request.Phone);

            await _repository.AddAsync(tutor);
            await _repository.SaveAsync();

            return _mapper.Map<TutorResponse>(tutor);
        }

        public async Task<bool> Handle(ChangeTutorPasswordCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            tutor.User.ChangePassword(command.Request.Password, command.Request.ConfirmPassword);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> Handle(DeleteTutorCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            await _repository.DeleteAsync(tutor);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<TutorResponse> Handle(ChangeTutorPropertiesCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            if (!string.IsNullOrEmpty(command.Request.Name)) //TODO isso é uma regra de dominio?
                tutor.ChangeName(command.Request.Name);
            if (!string.IsNullOrEmpty(command.Request.UrlImage))
                tutor.ChangeUrlImage(command.Request.UrlImage);
            if (!string.IsNullOrEmpty(command.Request.Phone))
                tutor.ChangePhone(command.Request.Phone);
            if (!string.IsNullOrEmpty(command.Request.About))
                tutor.ChangePhone(command.Request.About);
            if (!command.Request.CityId.HasValue || (!string.IsNullOrEmpty(command.Request.CityName) && !string.IsNullOrEmpty(command.Request.Uf))) //TODO isso é uma regra de dominio?
            {
                var city = await _cityRepository.GetByNameAsync(command.Request.CityName, command.Request.Uf);
                if (city != null)
                    tutor.ChangeAddress(command.Request.AddressDescription, city);
                else
                    tutor.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);
            }
            else if (!string.IsNullOrEmpty(command.Request.AddressDescription) || command.Request.CityId.HasValue || !string.IsNullOrEmpty(command.Request.CityName) || !string.IsNullOrEmpty(command.Request.Uf))
                tutor.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);

            await _repository.SaveAsync();

            return _mapper.Map<TutorResponse>(tutor);
        }

        public async Task<TutorResponse> Handle(ChangeTutorAboutCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            tutor.ChangeAbout(command.Request.About);
            await _repository.SaveAsync();
            return _mapper.Map<TutorResponse>(tutor);
        }

        public async Task<TutorResponse> Handle(ChangeTutorAddressCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            if (!command.Request.CityId.HasValue || (!string.IsNullOrEmpty(command.Request.CityName) && !string.IsNullOrEmpty(command.Request.Uf))) //TODO isso é uma regra de dominio?
            {
                var city = await _cityRepository.GetByNameAsync(command.Request.CityName, command.Request.Uf);
                if (city != null)
                    tutor.ChangeAddress(command.Request.AddressDescription, city);
                else
                    tutor.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);
            }
            else if (!string.IsNullOrEmpty(command.Request.AddressDescription) || command.Request.CityId.HasValue || !string.IsNullOrEmpty(command.Request.CityName) || !string.IsNullOrEmpty(command.Request.Uf))
                tutor.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);
            await _repository.SaveAsync();
            return _mapper.Map<TutorResponse>(tutor);
        }

        public async Task<TutorResponse> Handle(ChangeTutorNameCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            tutor.ChangeName(command.Request.Name);
            await _repository.SaveAsync();
            return _mapper.Map<TutorResponse>(tutor);
        }

        public async Task<TutorResponse> Handle(ChangeTutorPhoneCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            tutor.ChangePhone(command.Request.Phone);
            await _repository.SaveAsync();
            return _mapper.Map<TutorResponse>(tutor);
        }

        public async Task<TutorResponse> Handle(ChangeTutorUrlImageCommandRequest command, CancellationToken cancellationToken)
        {
            var tutor = await GetTutorByIdAsync(command.Id);
            tutor.ChangeUrlImage(command.Request.UrlImage);
            await _repository.SaveAsync();
            return _mapper.Map<TutorResponse>(tutor);
        }

        private async Task<Tutor> GetTutorByIdAsync(Guid id)
        {
            var tutor = await _repository.GetByIdAsync(id);
            if (tutor == null)
                throw new EntityNotFoundException();

            return tutor;
        }
    }
}
