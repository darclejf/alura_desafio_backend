using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.Enums;

namespace AluraChallenge.Adopet.Domain
{
    public class Pet : Entity
    {
        public string Name { get; private set; }
        public string Age { get; private set; }
        public PetSpecimen Specimen { get; private set; }
        public PetSize Size { get; private set; }
        //TODO criar tipo para comportamento?
        public string Behavior { get; private set; }
        public Guid ShelterId { get; private set; }
        public Shelter Shelter { get; private set; }
        public bool Adopeted { get; private set; }
        public Gender Gender { get; private set; }

        private Pet() { }

        public static Pet Create(
                                string? name, 
                                PetSpecimen specimen,
                                PetSize size,
                                string? behavior,
                                Gender gender,
                                string? age,
                                Shelter shelter)
        {
            var pet = new Pet()
            {
                Name = name,
                Age = age,
                Adopeted = false,
                Behavior = behavior,
                ShelterId = shelter.Id,
                Shelter = shelter,
                Specimen = specimen,
                Size = size,
                Gender = gender
            };

            //pet.AddDomainEvent(new CreateEntityDomainEvent<Pet>(pet));

            return pet;
        }

        public void WasAdopeted()
        {
            Adopeted = true;
        }

        public void NotAdopeted()
        {
            Adopeted = false;
        }
    }
}
