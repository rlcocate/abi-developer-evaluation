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

            RuleFor(item => item.Quantity)
                .LessThanOrEqualTo(20).WithMessage("It's not possible to sell above 20 identical items.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(item => item.Quantity)
                .Must(quantity => quantity < 4 || (quantity >= 4 && quantity < 10) || (quantity >= 10 && quantity <= 20))
                .WithMessage("Invalid discount rules.");

            RuleFor(item => item.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.")
                .Must((item, discount) => ValidateDiscount(item.Quantity, discount))
                .WithMessage("Invalid discount amount for the given quantity.");
        }
        
        private static bool ValidateDiscount(int quantity, decimal discount)
        {
            if (quantity >= 4 && quantity < 10)
            {
                return discount == 0.10m;
            }
            else if (quantity >= 10 && quantity <= 20)
            {
                return discount == 0.20m;
            }
            else if (quantity < 4)
            {
                return discount == 0;
            }

            return true;
        }
    }
}