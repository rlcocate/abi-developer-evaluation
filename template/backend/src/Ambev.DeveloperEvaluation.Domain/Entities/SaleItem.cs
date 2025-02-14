using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale item in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets the sale's id referenced.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets the sale's information.
        /// </summary>
        public Sale Sale { get; set; } = null!;

        /// <summary>
        /// Gets the product's id referenced.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the product's information.
        /// </summary>
        public Product Product { get; set; } = null!;

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

        /// <summary>
        /// Gets the total price applying discount.
        /// </summary>
        public decimal TotalPrice => ApplyDiscount(Quantity, TotalAmount);

        /// <summary>
        /// Performs validation of the sale entity using the SaleValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Sale number not empty</list>
        /// <list type="bullet">Sale date not empty</list>
        /// <list type="bullet">Customer id not empty</list>
        /// <list type="bullet">Customer required</list>
        /// <list type="bullet">Branch id not empty</list>
        /// <list type="bullet">Total sale amount grater than 0</list>
        /// <list type="bullet">Sale status not unknown</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// ApplyDiscount
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        private decimal ApplyDiscount(int quantity, decimal total)
        {
            decimal discount = 0;

            if (quantity >= 4 && quantity < 10)
            {
                discount = 0.10m;
            }
            else if (quantity >= 10 && quantity <= 20)
            {
                discount = 0.20m;
            }

            return quantity * total * (1 - discount);

        }
    }
}