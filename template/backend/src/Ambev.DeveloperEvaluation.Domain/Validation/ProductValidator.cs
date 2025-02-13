using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(branch => branch.ProductName)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .MaximumLength(150).WithMessage("Branch name cannot be longer than 50 characters.");

            RuleFor(branch => branch.UnitPrice)
                .NotEmpty()
                .GreaterThanOrEqualTo(0.01m).WithMessage("Minimum value is 0.01.");
        }
    }
}
