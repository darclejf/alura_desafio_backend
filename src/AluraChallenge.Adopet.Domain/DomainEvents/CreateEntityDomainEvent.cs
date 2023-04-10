using AluraChallenge.Adopet.Domain.Abstraction;
using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEvents
{
    /// <summary>
    /// Classe que representa um evento criado após inserir uma nova Entidade
    /// </summary>
    public class CreateEntityDomainEvent<T> : INotification where T : Entity
    {
        public T Entity { get; set; }

        public CreateEntityDomainEvent(T entity)
        {
            Entity = entity;
        }
    }
}
