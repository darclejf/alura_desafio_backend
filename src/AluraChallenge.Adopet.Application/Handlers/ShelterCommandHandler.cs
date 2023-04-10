using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class ShelterCommandHandler :
                                IRequestHandler<CreateShelterCommandRequest, ShelterResponse>,
                                IRequestHandler<ChangeShelterPropertiesCommandRequest, ShelterResponse>,
                                IRequestHandler<ChangeShelterAddressCommandRequest, ShelterResponse>,
                                IRequestHandler<ChangeShelterNameCommandRequest, ShelterResponse>,
                                IRequestHandler<ChangeShelterPhoneCommandRequest, ShelterResponse>,
                                IRequestHandler<ChangeShelterUrlImageCommandRequest, ShelterResponse>,
                                IRequestHandler<DeleteShelterCommandRequest, bool>,
                                IRequestHandler<AddPetCommandRequest, PetResponse>
    {
        private readonly IShelterRepository _repository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public ShelterCommandHandler(IShelterRepository repository, ICityRepository cityRepository, IMapper mapper)
        {
            _repository = repository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<ShelterResponse> Handle(CreateShelterCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = Shelter.Create(command.Request.Name,
                                   command.Request.Email,
                                   command.Request.Password,
                                   command.Request.ConfirmPassword,
                                   command.Request.Phone);

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return _mapper.Map<ShelterResponse>(entity);
        }

        public async Task<PetResponse> Handle(AddPetCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetShelterByIdAsync(command.Request.ShelterId);
            var pet = entity.AddPet(
                            name: command.Request.Name,
                            specimen: command.Request.Specimen,
                            size: command.Request.Size,
                            behavior: command.Request.Behavior, 
                            gender: command.Request.Gender, 
                            age: command.Request.Age);
            await _repository.SaveAsync();
            return _mapper.Map<PetResponse>(pet);
        }

        public async Task<ShelterResponse> Handle(ChangeShelterPropertiesCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetShelterByIdAsync(command.Id);
            if (!string.IsNullOrEmpty(command.Request.Name)) //TODO isso é uma regra de dominio?
                entity.ChangeName(command.Request.Name);
            if (!string.IsNullOrEmpty(command.Request.UrlImage))
                entity.ChangeUrlImage(command.Request.UrlImage);
            if (!string.IsNullOrEmpty(command.Request.Phone))
                entity.ChangePhone(command.Request.Phone);
            if (!string.IsNullOrEmpty(command.Request.About))
                entity.ChangePhone(command.Request.About);
            if (!command.Request.CityId.HasValue || (!string.IsNullOrEmpty(command.Request.CityName) && !string.IsNullOrEmpty(command.Request.Uf))) //TODO isso é uma regra de dominio?
            {
                var city = await _cityRepository.GetByNameAsync(command.Request.CityName, command.Request.Uf);
                if (city != null)
                    entity.ChangeAddress(command.Request.AddressDescription, city);
                else
                    entity.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);
            }
            else if (!string.IsNullOrEmpty(command.Request.AddressDescription) || command.Request.CityId.HasValue || !string.IsNullOrEmpty(command.Request.CityName) || !string.IsNullOrEmpty(command.Request.Uf))
                entity.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);

            await _repository.SaveAsync();
            return _mapper.Map<ShelterResponse>(entity); ;
        }

        public async Task<ShelterResponse> Handle(ChangeShelterAddressCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetShelterByIdAsync(command.Id);
            if (!command.Request.CityId.HasValue || (!string.IsNullOrEmpty(command.Request.CityName) && !string.IsNullOrEmpty(command.Request.Uf))) //TODO isso é uma regra de dominio?
            {
                var city = await _cityRepository.GetByNameAsync(command.Request.CityName, command.Request.Uf);
                if (city != null)
                    entity.ChangeAddress(command.Request.AddressDescription, city);
                else
                    entity.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);
            }
            else if (!string.IsNullOrEmpty(command.Request.AddressDescription) || command.Request.CityId.HasValue || !string.IsNullOrEmpty(command.Request.CityName) || !string.IsNullOrEmpty(command.Request.Uf))
                entity.ChangeAddress(command.Request.AddressDescription, command.Request.CityId, command.Request.CityName, command.Request.Uf);
            await _repository.SaveAsync();
            return _mapper.Map<ShelterResponse>(entity);
        }

        public async Task<ShelterResponse> Handle(ChangeShelterNameCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetShelterByIdAsync(command.Id);
            entity.ChangeName(command.Request.Name);
            await _repository.SaveAsync();
            return _mapper.Map<ShelterResponse>(entity);
        }

        public async Task<ShelterResponse> Handle(ChangeShelterPhoneCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetShelterByIdAsync(command.Id);
            entity.ChangePhone(command.Request.Phone);
            await _repository.SaveAsync();
            return _mapper.Map<ShelterResponse>(entity);
        }

        public async Task<ShelterResponse> Handle(ChangeShelterUrlImageCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetShelterByIdAsync(command.Id);
            entity.ChangeUrlImage(command.Request.UrlImage);
            await _repository.SaveAsync();
            return _mapper.Map<ShelterResponse>(entity);
        }

        public async Task<bool> Handle(DeleteShelterCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetShelterByIdAsync(command.Id);
            await _repository.DeleteAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        private async Task<Shelter> GetShelterByIdAsync(Guid id)
        {
            var tutor = await _repository.GetByIdAsync(id);
            if (tutor == null)
                throw new EntityNotFoundException();

            return tutor;
        }

    }
}
