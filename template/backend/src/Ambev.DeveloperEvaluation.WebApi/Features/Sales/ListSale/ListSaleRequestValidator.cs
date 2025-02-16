using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
    {
        public ListSaleRequestValidator()
        {
            RuleFor(s => s.Filter.SaleDateFrom)
                .LessThanOrEqualTo(s => s.Filter.SaleDateTo)
                .When(s => s.Filter.SaleDateFrom.HasValue && s.Filter.SaleDateTo.HasValue)
                .WithMessage("SaleDateFrom must be less than or equal to SaleDateTo.");
        }
    }
}
