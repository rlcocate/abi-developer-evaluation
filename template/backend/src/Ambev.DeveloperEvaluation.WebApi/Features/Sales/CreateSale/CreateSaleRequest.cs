using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the sale number to be created.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the customer's id referenced.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the branch's id referenced.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the total sale amount.
        /// </summary>
        public decimal TotalSaleAmount { get; set; }

        /// <summary>
        /// Gets or sets the sale status.
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the items of sale.
        /// </summary>
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
    }
}