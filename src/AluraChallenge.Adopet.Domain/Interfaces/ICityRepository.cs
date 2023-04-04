namespace AluraChallenge.Adopet.Domain.Interfaces
{
    /// <summary>
    /// Interface que representa um repositório para manter uma entidade do tipo City
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Método para criar uma nova Cidade
        /// </summary>
        /// <param name="city"></param>
        /// <returns><see cref="City"/></returns>
        Task<City> AddAsync(City entity);

        /// <summary>
        /// Método para excluir uma Cidade
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task DeleteAsync(City entity);

        /// <summary>
        /// Método para retornar uma entidade City por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="City"/></returns>
        Task<City?> GetByIdAsync(Guid id);

        /// <summary>
        /// Método para salvar as alterações (efetuar commit) em banco de dados
        /// </summary>
        /// <returns><see cref="int"/></returns>
        Task<int> SaveAsync();
    }
}
