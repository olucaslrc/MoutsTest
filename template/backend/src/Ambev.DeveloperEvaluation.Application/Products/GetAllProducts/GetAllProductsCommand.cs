using Ambev.DeveloperEvaluation.Application.Products.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

/// <summary>
/// Represents the command to retrieve all products.
/// </summary>
public class GetAllProductsCommand : IRequest<List<ProductResult>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllProductsCommand"/> class.
    /// </summary>
    public GetAllProductsCommand()
    {
    }
}
