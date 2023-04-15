namespace AluraChallenge.Adopet.Domain.Interfaces
{
    public interface IShelterRepository : IPersonRepository<Shelter>
    {
        Task<Pet?> GetPetByIdAsync(Guid petId);
    }
}
