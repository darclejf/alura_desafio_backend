using AluraChallenge.Adopet.Domain.Abstraction;

namespace AluraChallenge.Adopet.Domain.Interfaces
{
    public interface IPersonRepository<T> where T : Person
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<int> SaveAsync();
        Task<T?> GetByEmailAsync(string email);
    }
}
