using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateSaleHandler(_saleRepository, _mapper);
        }

        /// <summary>
        /// Tests that a valid sale creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid sale data When creating user Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateSaleHandlerTestData.GenerateValidCommand();

            Sale sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = command.SaleNumber,
                SaleDate = command.SaleDate,
                CustomerId = command.CustomerId,
                BranchId = command.BranchId,
                TotalSaleAmount = command.TotalSaleAmount,
                Status = command.Status,
                Items = command.Items
            };

            var result = new CreateSaleResult
            {
                Id = sale.Id,
            };

            _mapper.Map<Sale>(command).Returns(sale);
            _mapper.Map<CreateSaleResult>(sale).Returns(result);


            // When
            var createResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createResult.Should().NotBeNull();
            createResult.Id.Should().Be(sale.Id);
            await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }


        /// <summary>
        /// Tests that an invalid sale creation request throws a validation exception.
        /// </summary>
        [Fact(DisplayName = "Given invalid user data When creating sale Then throws validation exception")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = new CreateSaleCommand();

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }
    }
}
