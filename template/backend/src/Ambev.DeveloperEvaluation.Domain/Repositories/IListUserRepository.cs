using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IListUserRepository
    {
        /// <summary>
        /// Retrieves a list of users
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list user if found, null otherwise</returns>
        Task<List<User?>> ListAsync(CancellationToken cancellationToken = default);
    }
}
