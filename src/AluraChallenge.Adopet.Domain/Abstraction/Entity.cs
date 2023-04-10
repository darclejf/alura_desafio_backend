using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AluraChallenge.Adopet.Domain.Abstraction
{
    /// <summary>
    /// Classe abstrata que representa uma entidade de domínio <see cref="Entity" />.
    /// </summary>
    public abstract class Entity
    {
        [Required]
        public Guid Id { get; protected set; }
        public List<INotification>? DomainEvents { get; protected set; }

        public void AddDomainEvent(INotification eventItem)
        {
            DomainEvents ??= new List<INotification>();
            DomainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            DomainEvents?.Remove(eventItem);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString() + " " + Id;
        }
    }
}
