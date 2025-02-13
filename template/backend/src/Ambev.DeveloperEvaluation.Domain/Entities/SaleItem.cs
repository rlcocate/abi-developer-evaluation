using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale item in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets the sale's information.
        /// Required.
        /// </summary>
        public required Sale Sale { get; set; }

        /// <summary>
        /// Gets the product's information.
        /// Required.
        /// </summary>
        public required Product Product { get; set; }

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