using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEvents
{
    public class ValidateCityExistsDomainEventHandler : INotificationHandler<CreateCityDomainEvent>
    {
        private readonly ICityRepository _cityRepository;

        public ValidateCityExistsDomainEventHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task Handle(CreateCityDomainEvent notification, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetByIdAsync(notification.City.Id) ;
            if (city == null)
                await _cityRepository.AddAsync(notification.City);
        }
    }
}
