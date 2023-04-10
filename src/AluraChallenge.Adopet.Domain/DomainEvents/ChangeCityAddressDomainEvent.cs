using AluraChallenge.Adopet.Domain.Abstraction;
using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEvents
{
    public class ChangeCityAddressDomainEvent : INotification
    {
        public Person Person { get; set; }

        public ChangeCityAddressDomainEvent(Person person)
        {
            Person = person;
        }
    }
}
