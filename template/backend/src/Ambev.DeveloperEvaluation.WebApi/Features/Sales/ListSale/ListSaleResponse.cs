using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSaleResponse
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public Customer Customer { get; set; } = null!;
        public Branch Branch { get; set; } = null!;
        public decimal TotalSaleAmount { get; set; }
        public SaleStatus Status { get; set; }
        public List<ListSaleItemResponse> Items { get; set; } = new();
    }
}
