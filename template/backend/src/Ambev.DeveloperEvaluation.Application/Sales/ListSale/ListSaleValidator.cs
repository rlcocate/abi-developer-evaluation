using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    public class ListSaleValidator : AbstractValidator<ListSaleCommand>
    {
        public ListSaleValidator()
        {
            RuleFor(x => x.Filter)
                .NotNull()
                .WithMessage("Filter criteria is required");
        }
    }
}
