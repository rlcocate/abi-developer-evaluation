using Ambev.DeveloperEvaluation.Application.Sales.ListSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSaleProfile: Profile
    {
        public ListSaleProfile()
        {
            CreateMap<ListSaleRequest, ListSaleCommand>();
            CreateMap<ListSaleResult, ListSaleResponse>();
            CreateMap<ListSaleItemResult, ListSaleItemResponse>();
        }
    }
}
