using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(item => item.Sale)
                .NotNull().WithMessage("Sale information is required.");

            RuleFor(item => item.Product)
                .NotNull().WithMessage("Product information is required.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(item => item.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount must be at least 0.");

            RuleFor(item => item.TotalAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Total amount must be at least 0.");
        }
    }
}