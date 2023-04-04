using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.DomainEvents;

namespace AluraChallenge.Adopet.Domain
{
    public class City : Entity
    {
        public string Name { get; private set; }
        public string UF { get; private set; }

        private City() { }

        protected City(Guid id, string? name, string? uf)
        {
            if (string.IsNullOrEmpty(name))
                throw new EmptyNameException();

            if (string.IsNullOrEmpty(uf))
                throw new NotImplementedException();

            Id = id;
            Name = name;
            UF = uf;

            AddDomainEvent(new CreateCityDomainEvent(this));
        }

        public static City Create(Guid? id, string? name, string? uf)
        {
            if (id.HasValue)
                return new City(id.Value, name, uf);
            return new City(Entity.GenerateNewEntityId(), name, uf);
        }

        public static City Create(string? name, string? uf)
        {
            return new City(Entity.GenerateNewEntityId(), name, uf);
        }
    }
}
