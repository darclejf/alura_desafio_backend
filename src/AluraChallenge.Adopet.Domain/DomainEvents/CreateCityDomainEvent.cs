using MediatR;

namespace AluraChallenge.Adopet.Domain.DomainEvents
{
    /// <summary>
    /// Classe que representa um evento criado após alterar uma cidade de um Tutor
    /// </summary>
    public class CreateCityDomainEvent : INotification
    {
        public City City { get; set; }    

        public CreateCityDomainEvent(City city)
        {
            City = city;
        }        
    }
}
