using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEventsHandlers
{
    public class ValidateCityExistsDomainEventHandler : INotificationHandler<ChangeCityAddressDomainEvent>
    {
        private readonly ICityRepository _cityRepository;

        public ValidateCityExistsDomainEventHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task Handle(ChangeCityAddressDomainEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Person.CityId.HasValue)
            {
                var city = await _cityRepository.GetByIdAsync(notification.Person.CityId.Value);
                if (city == null && notification.Person.City != null)
                    await _cityRepository.AddAsync(notification.Person.City);
            }
        }
    }
}
