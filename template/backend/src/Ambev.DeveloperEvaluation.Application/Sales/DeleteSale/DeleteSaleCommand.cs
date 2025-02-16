using MediatR;

/// <summary>
/// Command for deleting a sale
/// </summary>
namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
    {
        /// <summary>
        /// Initializes a new instance of DeleteSaleCommand
        /// </summary>
        /// <param name="id">The ID of the sale to delete</param>
        public DeleteSaleCommand(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// The unique identifier of the sale to delete
        /// </summary>
        public Guid Id { get; }
    }
}