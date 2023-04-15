using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.DomainEvents;

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
                        Guid userId,
                        string about = "") : base(name, email, phone, userId) 
        {
            About = about;
            AddDomainEvent(new CreateEntityDomainEvent<Tutor>(this));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="userId"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static Tutor Create(string name,
                                    string email,
                                    Guid userId,
                                    string phone = "")
        {
            var tutor = new Tutor(name, email, phone, userId);
            return tutor;
        }

        public void ChangeAbout(string? about)
        {
            About = about;
        }
    }
}
