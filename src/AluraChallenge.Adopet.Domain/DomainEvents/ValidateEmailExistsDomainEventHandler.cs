using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Interfaces;
using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEvents
{
    public class ValidateEmailExistsDomainEventHandler : INotificationHandler<CreateTutorDomainEvent>
    {
        private readonly ITutorRepository _tutorRepository;

        public ValidateEmailExistsDomainEventHandler(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        public async Task Handle(CreateTutorDomainEvent notification, CancellationToken cancellationToken)
        {
            var tutor = await _tutorRepository.GetByEmailAsync(notification.Tutor.Email.Address);
            if (tutor != null)
                throw new ExistsEmailException();
        }
    }
}
