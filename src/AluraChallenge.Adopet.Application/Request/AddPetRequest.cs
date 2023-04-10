using AluraChallenge.Adopet.Domain.Enums;

namespace AluraChallenge.Adopet.Application.Request
{
    public class AddPetRequest
    {
        public Guid ShelterId { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public PetSpecimen Specimen { get; set; }
        public PetSize Size { get; set; }
        public string? Behavior { get; set; }
        public Gender Gender { get; set; }
    }
}
