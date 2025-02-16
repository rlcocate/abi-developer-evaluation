using Ambev.DeveloperEvaluation.Common.Filters;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    public record ListSaleCommand : IRequest<List<ListSaleResult>>
    {
        public ListSaleFilter Filter { get; }

        public ListSaleCommand(ListSaleFilter filter)
        {
            Filter = filter;
        }
    }

}
