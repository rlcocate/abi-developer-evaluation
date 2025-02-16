using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleCommand that defines validation rules for sale creation command.
    /// </summary>
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        ///     Sale number needs to be filled 
        ///     Sale date needs to be filled
        ///     Customer ID is required
        ///     Branch ID is required
        ///     Total sale amount must be greater than 0
        ///     Sale status cannot be unknown
        ///     Items of sale must be filled
        /// </remarks>
        public CreateSaleValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number needs to be filled.");

            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("Sale date needs to be filled.");

            RuleFor(sale => sale.CustomerId)
                .NotNull().WithMessage("Customer ID is required.");

            RuleFor(sale => sale.BranchId)
                .NotNull().WithMessage("Branch ID is required.");

            RuleFor(sale => sale.TotalSaleAmount)
                .GreaterThan(0).WithMessage("Total sale amount must be greater than 0.");

            RuleFor(sale => sale.Status)
                .NotEqual(SaleStatus.Unknown).WithMessage("Sale status cannot be unknown.");

            RuleFor(sale => sale.Status)
                .IsInEnum().WithMessage("Sale status cannot be unknown.");

            RuleForEach(sale => sale.Items).SetValidator(new SaleItemValidator());
        }
    }
}
