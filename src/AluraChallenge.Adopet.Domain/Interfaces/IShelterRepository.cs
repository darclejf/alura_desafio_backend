namespace AluraChallenge.Adopet.Domain.Interfaces
{
    public interface IShelterRepository
    {
        Task<Shelter> AddAsync(Shelter entity);
        Task UpdateAsync(Shelter entity);
        Task DeleteAsync(Shelter entity);
        Task<Shelter?> GetByIdAsync(Guid id);
        Task<int> SaveAsync();
        Task<Shelter?> GetByEmailAsync(string email);
        Task<Pet?> GetPetByIdAsync(Guid petId);
    }
}
