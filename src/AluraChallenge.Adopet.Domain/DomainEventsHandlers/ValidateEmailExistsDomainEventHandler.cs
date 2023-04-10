using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEventsHandlers
{
    public class ValidateEmailExistsDomainEventHandler : INotificationHandler<CreateEntityDomainEvent<Tutor>>,
                                                        INotificationHandler<CreateEntityDomainEvent<Shelter>>
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly IShelterRepository _shelterRepository;

        public ValidateEmailExistsDomainEventHandler(ITutorRepository tutorRepository, IShelterRepository shelterRepository)
        {
            _tutorRepository = tutorRepository;
            _shelterRepository = shelterRepository;
        }

        public async Task Handle(CreateEntityDomainEvent<Tutor> notification, CancellationToken cancellationToken)
        {
            var entity = notification.Entity;
            var tutor = await _tutorRepository.GetByEmailAsync(entity.Email.Address);
            if (tutor != null)
                throw new ExistsEmailException();
        }

        public async Task Handle(CreateEntityDomainEvent<Shelter> notification, CancellationToken cancellationToken)
        {
            var entity = notification.Entity;
            var tutor = await _shelterRepository.GetByEmailAsync(entity.Email.Address);
            if (tutor != null)
                throw new ExistsEmailException();
        }
    }
}
