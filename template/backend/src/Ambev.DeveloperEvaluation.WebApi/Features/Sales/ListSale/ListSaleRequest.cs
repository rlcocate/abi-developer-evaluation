using Ambev.DeveloperEvaluation.Common.Filters;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSaleRequest
    {
        public ListSaleFilter Filter { get; set; } = null!;
    }
}
