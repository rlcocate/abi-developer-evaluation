using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    public class ListSaleItemResult
    {
        public Guid Id { get; set; }
        public Sale Sale { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
