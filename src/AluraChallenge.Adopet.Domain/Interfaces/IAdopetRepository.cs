namespace AluraChallenge.Adopet.Domain.Interfaces
{
    public interface IAdopetRepository
    {
        Task<Adopet> AddAsync(Adopet entity);
        Task DeleteAsync(Adopet entity);
        Task<Adopet?> GetByIdAsync(Guid id);
        Task<Adopet?> GetByPetIdAsync(Guid petId);
        Task<int> SaveAsync();
    }
}
