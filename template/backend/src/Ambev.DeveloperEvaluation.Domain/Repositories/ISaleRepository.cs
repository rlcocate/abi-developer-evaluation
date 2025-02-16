using Ambev.DeveloperEvaluation.Common.Filters;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        /// <summary>
        /// Retrieves a list of users
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list user if found, null otherwise</returns>
        Task<List<Sale>> ListAsync(ListSaleFilter filter, CancellationToken cancellationToken = default);
    }
}
