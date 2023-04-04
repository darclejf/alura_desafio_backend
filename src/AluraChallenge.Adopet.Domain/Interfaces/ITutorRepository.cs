namespace AluraChallenge.Adopet.Domain.Interfaces
{
    /// <summary>
    /// Interface que representa um repositório para manter uma entidade do tipo Tutor 
    /// </summary>
    public interface ITutorRepository
    {
        /// <summary>
        /// Método para criar um novo Tutor com seu usuário vinculado
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns><see cref="Tutor"/></returns>
        Task<Tutor> AddAsync(Tutor tutor);

        /// <summary>
        /// Método para atualizar um Tutor
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns></returns>
        Task UpdateAsync(Tutor tutor);

        /// <summary>
        /// Método para excluir um Tutor e seu Usuário
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns></returns>
        Task DeleteAsync(Tutor tutor);

        /// <summary>
        /// Método para retornar uma entidade Tutor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Tutor"/></returns>
        Task<Tutor?> GetByIdAsync(Guid id);

        /// <summary>
        /// Método para retornar uma entidade Tutor por email
        /// </summary>
        /// <param name="email"></param>
        /// <returns><see cref="Tutor"/></returns>
        Task<Tutor?> GetByEmailAsync(string email);

        /// <summary>
        /// Método para salvar as alterações (efetuar commit) em banco de dados
        /// </summary>
        /// <returns><see cref="int"/></returns>
        Task<int> SaveAsync();
    }
}
