using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.Interfaces;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class BasePersonHandler<T> where T : Person
    {
        protected readonly IPersonRepository<T> _repository;
        protected readonly ICityRepository _cityRepository;

        public BasePersonHandler(IPersonRepository<T> repository, ICityRepository cityRepository)
        {
            _repository = repository;
            _cityRepository = cityRepository;
        }

        protected virtual async Task<T> ChangePropertiesAsync(Guid personId, UpdatePersonRequest request)
        {
            var entity = await GetByIdAsync(personId);
            if (!string.IsNullOrEmpty(request.Name)) //TODO isso é uma regra de dominio?
                entity.ChangeName(request.Name);
            if (!string.IsNullOrEmpty(request.UrlImage))
                entity.ChangeUrlImage(request.UrlImage);
            if (!string.IsNullOrEmpty(request.Phone))
                entity.ChangePhone(request.Phone);
            if (!request.CityId.HasValue || (!string.IsNullOrEmpty(request.CityName) && !string.IsNullOrEmpty(request.Uf))) //TODO isso é uma regra de dominio?
            {
                var city = await _cityRepository.GetByNameAsync(request.CityName, request.Uf);
                if (city != null)
                    entity.ChangeAddress(request.AddressDescription, city);
                else
                    entity.ChangeAddress(request.AddressDescription, request.CityId, request.CityName, request.Uf);
            }
            else if (!string.IsNullOrEmpty(request.AddressDescription) || request.CityId.HasValue || !string.IsNullOrEmpty(request.CityName) || !string.IsNullOrEmpty(request.Uf))
                entity.ChangeAddress(request.AddressDescription, request.CityId, request.CityName, request.Uf);

            await _repository.SaveAsync();
            return entity;
        }

        protected async Task<T> ChangeAddressAsync(Guid personId, AddressRequest request)
        {
            var entity = await GetByIdAsync(personId);
            if (!request.CityId.HasValue || (!string.IsNullOrEmpty(request.CityName) && !string.IsNullOrEmpty(request.Uf))) //TODO isso é uma regra de dominio?
            {
                var city = await _cityRepository.GetByNameAsync(request.CityName, request.Uf);
                if (city != null)
                    entity.ChangeAddress(request.AddressDescription, city);
                else
                    entity.ChangeAddress(request.AddressDescription, request.CityId, request.CityName, request.Uf);
            }
            else if (!string.IsNullOrEmpty(request.AddressDescription) || request.CityId.HasValue || !string.IsNullOrEmpty(request.CityName) || !string.IsNullOrEmpty(request.Uf))
                entity.ChangeAddress(request.AddressDescription, request.CityId, request.CityName, request.Uf);
            await _repository.SaveAsync();
            return entity;
        }

        protected async Task<T> ChangeNameAsync(Guid personId, NameRequest request)
        {
            var entity = await GetByIdAsync(personId);
            entity.ChangeName(request.Name);
            await _repository.SaveAsync();
            return entity;
        }

        protected async Task<T> ChangePhoneAsync(Guid personId, PhoneRequest request)
        {
            var entity = await GetByIdAsync(personId);
            entity.ChangePhone(request.Phone);
            await _repository.SaveAsync();
            return entity;
        }

        protected async Task<T> ChangeUrlImageAsync(Guid personId, UrlImageRequest request)
        {
            var entity = await GetByIdAsync(personId);
            entity.ChangeUrlImage(request.UrlImage);
            await _repository.SaveAsync();
            return entity;
        }

        protected async Task<bool> DeleteAsync(Guid personId)
        {
            var entity = await GetByIdAsync(personId);
            await _repository.DeleteAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        protected async Task<T> GetByIdAsync(Guid id)
        {
            var tutor = await _repository.GetByIdAsync(id);
            if (tutor == null)
                throw new EntityNotFoundException();

            return tutor;
        }
    }
}
