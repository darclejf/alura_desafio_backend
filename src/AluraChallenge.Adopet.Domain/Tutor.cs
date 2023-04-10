using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.Enums;

namespace AluraChallenge.Adopet.Domain
{
    /// <summary>
    /// Classe que representa a entidade de domínio Tutor <see cref="Tutor" />.
    /// </summary>
    public sealed class Tutor : Person
    {
        public string? About { get; private set; }

        private Tutor() { }

        private Tutor(string name,
                        string email,
                        string phone,
                        string password,
                        string confirmaPassword,
                        string about = "") : base(name, email, phone, password, confirmaPassword, ProfileRole.Tutor) 
        {
            About = about;
            AddDomainEvent(new CreateEntityDomainEvent<Tutor>(this));
        }

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
                                    string phone = "")
        {
            var tutor = new Tutor(name, email, phone, password, confirmPassword);
            return tutor;
        }

        public void ChangeAbout(string? about)
        {
            About = about;
        }
    }
}
