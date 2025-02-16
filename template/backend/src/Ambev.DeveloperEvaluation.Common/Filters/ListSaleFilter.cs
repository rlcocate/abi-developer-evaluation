namespace Ambev.DeveloperEvaluation.Common.Filters
{
    public class ListSaleFilter
    {
        public DateTime? SaleDateFrom { get; set; }
        public DateTime? SaleDateTo { get; set; }
        public string? CustomerName { get; set; } = null;
        public string? BranchName { get; set; } = null;
    }
}
