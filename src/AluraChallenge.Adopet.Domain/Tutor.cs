using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Core.ValueObjects;
using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.DomainEvents;

namespace AluraChallenge.Adopet.Domain
{
    /// <summary>
    /// Classe que representa a entidade de domínio Tutor <see cref="Tutor" />.
    /// </summary>
    public sealed class Tutor : Entity
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public string? Phone { get; private set; }
        public string Password { get; private set; }
        public string? UrlImage { get; private set; }
        public ResponsibleType Type { get; private set; }
        public Guid? CityId { get; private set; }
        public City? City { get; private set; }

        private Tutor() { }

        /// <summary>
        /// Método que cria um objeto do tipo Tutor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <param name="phone"></param>
        /// <returns>Tutor</returns>
        /// <exception cref="EmptyNameException"></exception>
        public static Tutor Create(string name,
                                    string email,
                                    string password,
                                    string confirmPassword,
                                    string phone = "",
                                    ResponsibleType type = ResponsibleType.Individual)
        {
            var emailObject = new Email(email);

            var tutor = new Tutor()
            {
                Id = Entity.GenerateNewEntityId(),
                Name = name,
                Email = emailObject,
            };

            tutor.ChangeName(name);
            tutor.ChangePhone(phone);
            tutor.ChangePassword(password, confirmPassword);
            tutor.ChangeType(type);

            tutor.AddDomainEvent(new CreateTutorDomainEvent(tutor));

            return tutor;
        }

        public void ChangeUrlImage(string urlImage)
        {
            UrlImage = urlImage;
        }
        public void ChangeType(ResponsibleType type)
        {
            Type = type;
        }

        public void ChangeCity(City city)
        {
            CityId = city.Id;
            City = city;
        }

        /// <summary>
        /// Método para atualizar o nome do Tutor
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="EmptyNameException"></exception>
        public void ChangeName(string name)
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

        /// <summary>
        /// Método para alterar a senha do tutor
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        public void ChangePassword(string password, string confirmPassword)
        {
            ValidatePassword(password, confirmPassword);
            Password = password;
        }

        private static void ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password))
                throw new InvalidPasswordException();

            //TODO implementar validacao com regex
            //A senha deve conter pelo menos uma letra maiúscula, um número e ter entre 6 e 15 caracteres

            if (password != confirmPassword)
                throw new InvalidConfirmationPasswordException();
        }
    }
}
