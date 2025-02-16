using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class CreateSaleHandlerTestData
    {

        //private static readonly Faker<SaleItem> itemFaker = new Faker<SaleItem>()
        //    //.RuleFor(item => item.Id, f => f.IndexFaker)// f.IndexFaker + 1
        //    .RuleFor(item => item.Name, f => f.Commerce.ProductName())
        //    .RuleFor(item => item.Price, f => f.Commerce.Price())
        //    .RuleFor(item => item.Quantity, f => f.Random.Int(1, 10));

        private static readonly Faker<SaleItem> itemFaker = new Faker<SaleItem>();

        private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
            .RuleFor(sale => sale.SaleNumber, f => f.Random.AlphaNumeric(5))
            .RuleFor(sale => sale.SaleDate, f => f.Date.Recent(1))
            .RuleFor(sale => sale.CustomerId, f => f.Random.Guid())
            .RuleFor(sale => sale.BranchId, f => f.Random.Guid())
            .RuleFor(sale => sale.TotalSaleAmount, f => f.Finance.Amount(1, 950))
            .RuleFor(sale => sale.Status, f => f.PickRandom(SaleStatus.NotCancelled))
            .RuleFor(sale => sale.Items, f => itemFaker.Generate(f.Random.Int(1, 10)));

        public static CreateSaleCommand GenerateValidCommand()
        {
            return createSaleHandlerFaker.Generate();
        }
    }
}
