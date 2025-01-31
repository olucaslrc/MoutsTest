using Ambev.DeveloperEvaluation.Application.Products.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Represents the command to retrieve a product by its ID.
/// </summary>
public class GetProductCommand : IRequest<ProductResult>
{
    /// <summary>
    /// Gets the unique identifier of the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductCommand"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    public GetProductCommand(Guid id)
    {
        Id = id;
    }
}
