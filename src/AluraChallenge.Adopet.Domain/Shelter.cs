using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.Enums;

namespace AluraChallenge.Adopet.Domain
{
    public sealed class Shelter : Person
    {
        public IList<Pet> Pets { get; private set; }

        private Shelter() { }

        private Shelter(string name,
                        string email,
                        string phone,
                        string password,
                        string confirmaPassword) : base(name, email, phone, password, confirmaPassword, ProfileRole.Shelter) 
        {
            AddDomainEvent(new CreateEntityDomainEvent<Shelter>(this));
        }

        public static Shelter Create(string name,
                        string email,
                        string phone,
                        string password,
                        string confirmaPassword)
        {
            return new Shelter(name, email, phone, password, confirmaPassword);
        }

        public Pet AddPet(string? name,
                            PetSpecimen specimen,
                            PetSize size,
                            string? behavior,
                            Gender gender,
                            string? age)
        {
            var pet = Pet.Create(name, specimen, size, behavior, gender, age, this);
            if (Pets == null)
                Pets = new List<Pet>();
            Pets.Add(pet);
            return pet;
        }
    }
}
