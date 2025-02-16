using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
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
