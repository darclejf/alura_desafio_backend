using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.Enums;

namespace AluraChallenge.Adopet.Domain
{
    public class Pet : Entity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Months { get; private set; }
        public PetSpecimen Specimen { get; private set; }
        public PetSize Size { get; private set; }
        //TODO criar tipo para comportamento?
        public string Behavior { get; private set; }
        public Guid ResponsibleId { get; private set; }
        public Tutor Responsible { get; private set; }
        public bool Adopeted { get; private set; }
        public Gender Gender { get; private set; }

        private Pet() { }

        public static Pet Create(
                                string name, 
                                PetSpecimen specimen,
                                PetSize size,
                                string behavior,
                                Tutor responsible,
                                Gender gender,
                                int age = 0,
                                int months = 0)
        {

            return new Pet()
            {
                Id = Entity.GenerateNewEntityId(),
                Name = name,
                Age = age,
                Adopeted = false,
                Behavior = behavior,
                ResponsibleId = responsible.Id,
                Responsible = responsible,
                Months = months,
                Specimen = specimen,
                Size = size,
                Gender = gender
            };
        }
    }
}
