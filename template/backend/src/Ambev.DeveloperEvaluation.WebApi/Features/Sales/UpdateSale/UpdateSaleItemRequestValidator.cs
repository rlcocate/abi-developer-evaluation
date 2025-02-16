using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemRequestValidator()
        {
            RuleFor(si => si.ProductId)
                .NotEmpty().WithMessage("Product ID cannot be empty.");

            RuleFor(si => si.Quantity)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Quantity must be higher than 0.");

            RuleFor(si => si.TotalAmount)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Total amount must be higher than 0.");
        }
    }
}
