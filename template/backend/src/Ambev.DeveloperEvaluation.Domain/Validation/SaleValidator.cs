using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number needs to be filled.");

            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("Sale date needs to be filled.");

            RuleFor(sale => sale.Customer)
                .NotNull().WithMessage("Customer information is required.");

            RuleFor(sale => sale.Branch)
                .NotNull().WithMessage("Branch information is required.");

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