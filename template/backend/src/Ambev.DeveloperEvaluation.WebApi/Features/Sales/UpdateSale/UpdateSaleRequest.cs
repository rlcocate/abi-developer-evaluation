using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequest : BaseEntity
    {

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
        public SaleStatus Status { get; set; } = SaleStatus.NotCancelled;

        /// <summary>
        /// Gets or sets the items of sale.
        /// </summary>
        public List<UpdateSaleItemRequest> Items { get; set; } = new List<UpdateSaleItemRequest>();
    }
}
