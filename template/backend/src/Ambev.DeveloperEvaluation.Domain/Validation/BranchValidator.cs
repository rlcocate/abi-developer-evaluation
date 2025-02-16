using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(branch => branch.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .MaximumLength(150).WithMessage("Branch name cannot be longer than 50 characters.");

            RuleFor(branch => branch.Location)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Location must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Location cannot be longer than 50 characters.");
        }
    }
}
