using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Core.ValueObjects;
using AluraChallenge.Adopet.Domain.DomainEvents;

namespace AluraChallenge.Adopet.Domain.Abstraction
{
    public abstract class Person : Entity
    {
        public string Name { get; protected set; }
        public string? AddressDescription { get; protected set; }
        public Guid? CityId { get; protected set; }
        public City? City { get; protected set; }
        public Guid UserId { get; protected set; }
        public Email Email { get; protected set; }
        public string? Phone { get; protected set; }
        public string? UrlImage { get; private set; }

        protected Person() { }

        protected Person(string name, 
                        string email, 
                        string phone,
                        Guid userId,
                        string urlImage = null)
        {
            var emailValueObject = new Email(email);
            UserId = userId;
            Email = emailValueObject;

            ChangeName(name);
            ChangePhone(phone);
            ChangeUrlImage(urlImage);
        }

        /// <summary>
        /// Método para atualizar o nome do Tutor
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="EmptyNameException"></exception>
        public void ChangeName(string? name)
        {
            if (string.IsNullOrEmpty(name))
                throw new EmptyNameException();
            Name = name;
        }

        /// <summary>
        /// Método para atualizar o telefone do Tutor
        /// </summary>
        /// <param name="phone"></param>
        public void ChangePhone(string? phone)
        {
            Phone = phone;
        }

        public void ChangeUrlImage(string? urlImage)
        {
            UrlImage = urlImage;
        }

        public void ChangeAddress(string? addressDescription, Guid? cityId, string? cityName, string? uf)
        {
            AddressDescription = addressDescription;
            if (cityId.HasValue || !string.IsNullOrEmpty(cityName) || !string.IsNullOrEmpty(uf))
            {
                var city = City.Create(cityId, cityName, uf);
                City = city;
                CityId = City.Id;
                AddDomainEvent(new ChangeCityAddressDomainEvent(this));
            }
        }

        public void ChangeAddress(string? addressDescription, City city)
        {
            AddressDescription = addressDescription;
            City = city;
            CityId = City.Id;
            AddDomainEvent(new ChangeCityAddressDomainEvent(this));
        }
    }
}
