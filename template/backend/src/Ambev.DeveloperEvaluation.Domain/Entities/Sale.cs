using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Sale: BaseEntity
    {
        /// <summary>
        /// Gets the sale's number.
        /// Must not be null or empty.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets the sale's date.
        /// Must not be null or empty.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets the customer's information.
        /// Required.
        /// </summary>
        public required Customer Customer { get; set; }

        /// <summary>
        /// Gets the branch's information.
        /// Required.
        /// </summary>
        public required Branch Branch { get; set; }

        /// <summary>
        /// Gets the total sale amount.
        /// Must be greater than 0, not null.
        /// </summary>
        public decimal TotalSaleAmount { get; set; }

        /// <summary>
        /// Gets the sale status.
        /// Cannot be unknown.
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Mark the sale status as cancelled.
        /// </summary>
        public void Cancel()
        {
            Status = SaleStatus.Cancelled;
        }

        /// <summary>
        /// Mark the sale status as not cancelled.
        /// </summary>
        public void NotCancelled()
        {
            Status = SaleStatus.NotCancelled;
        }

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
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}