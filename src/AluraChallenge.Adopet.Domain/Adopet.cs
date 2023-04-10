using AluraChallenge.Adopet.Domain.Abstraction;

namespace AluraChallenge.Adopet.Domain
{
    public class Adopet : Entity
    {
        public Guid TutorId { get; private set; }
        public Tutor Tutor { get; private set; }
        public Guid PetId { get; private set; }
        public Pet Pet { get; private set; }
        public DateTime DateTime { get; private set; }

        private Adopet() { }

        public  static Adopet Create(Tutor tutor, Pet pet)
        {
            pet.WasAdopeted();
            return new Adopet
            {
                TutorId = tutor.Id,
                Tutor = tutor,
                PetId = pet.Id,
                Pet = pet,
                DateTime = DateTime.Now,
            };
        }
    }
}
