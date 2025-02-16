using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleItemRequest: BaseEntity
    {
        /// <summary>
        /// Gets the product's id referenced.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the quantity of item.
        /// Must be greater than 0, not null.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the discount of item.
        /// Minimum value is 0.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets the total amount of item.
        /// Minimum value is 0.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
