using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSaleItemResponse
    {
        public Guid Id { get; set; }
        public Sale Sale { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
