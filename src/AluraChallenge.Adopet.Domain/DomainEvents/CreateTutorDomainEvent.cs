using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEvents
{
    /// <summary>
    /// Classe que representa um evento criado após inserir um novo Tutor
    /// </summary>
    public class CreateTutorDomainEvent : INotification
    {
        public Tutor Tutor { get; set; }

        public CreateTutorDomainEvent(Tutor tutor)
        {
            Tutor = tutor;
        }
    }
}
