using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
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

            RuleForEach(sale => sale.Items).SetValidator(new UpdateSaleItemRequestValidator());
        }
    }
}
