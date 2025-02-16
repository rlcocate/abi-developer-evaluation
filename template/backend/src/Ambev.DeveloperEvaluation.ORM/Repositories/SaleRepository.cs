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
        
        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
        
        /// <summary>
        /// Creates a new sale in the database
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }
        
        /// <summary>
        ///  Updates an existing sale in the database
        /// </summary>
        /// <param name="sale">The sale to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale</returns>
        /// <exception cref="InvalidOperationException"></exception>        
        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            var existingSale = await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == sale.Id, cancellationToken);

            if (existingSale == null)
            {
                throw new InvalidOperationException($"Sale with id {sale.Id} not found");
            }

            // Atualizar propriedades da Sale
            existingSale.CustomerId = sale.CustomerId;
            existingSale.BranchId = sale.BranchId;
            existingSale.TotalSaleAmount = sale.TotalSaleAmount;
            existingSale.Status = sale.Status;

            // Atualizar Items
            foreach (var item in sale.Items)
            {
                var existingItem = existingSale.Items.FirstOrDefault(si => si.Id == item.Id);

                if (existingItem != null)
                {
                    // Atualizar item existente
                    existingItem.ProductId = item.ProductId;
                    existingItem.Quantity = item.Quantity;
                    existingItem.Discount = item.Discount;
                    existingItem.TotalAmount = item.TotalAmount;
                    // Não precisa definir o estado do `existingItem`, pois ele já está sendo rastreado
                }
                else
                {
                    // Adicionar novo item e definir o SaleId corretamente
                    item.SaleId = existingSale.Id;
                    // Adicionar ao contexto do Entity Framework
                    _context.Entry(item).State = EntityState.Added;
                }
            }

            // Remover Items que não estão mais presentes
            foreach (var existingItem in existingSale.Items.ToList())
            {
                if (!sale.Items.Any(si => si.Id == existingItem.Id))
                {
                    // Remover o item do contexto do Entity Framework
                    _context.SaleItems.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return existingSale;
        }


        /// <summary>
        /// Deletes a sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
