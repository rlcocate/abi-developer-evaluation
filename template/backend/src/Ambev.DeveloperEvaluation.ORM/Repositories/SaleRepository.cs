using Ambev.DeveloperEvaluation.Common.Filters;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of sales
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Sale>> ListAsync(ListSaleFilter filter, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Sale>()
                .Include(c => c.Customer)
                .Include(b => b.Branch)
                .Include(si => si.Items).ThenInclude(p => p.Product)
                .AsQueryable();

            if (filter.SaleDateFrom.HasValue)
                query = query
                    .Where(s => s.SaleDate >= filter.SaleDateFrom.Value);

            if (filter.SaleDateTo.HasValue)
                query = query
                    .Where(s => s.SaleDate <= filter.SaleDateTo.Value);

            if (!string.IsNullOrEmpty(filter.CustomerName))
                query = query
                    .Where(s => s.Customer.FirstName.ToLower().Contains(filter.CustomerName.ToLower()) ||
                                s.Customer.LastName.ToLower().Contains(filter.CustomerName.ToLower()));

            if (!string.IsNullOrEmpty(filter.BranchName))
                query = query
                    .Where(s => s.Branch.Name.Contains(filter.BranchName));
            var result = await query
                .ToListAsync(cancellationToken);
            return result;
        }
    }
}
