using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.Common;

/// <summary>
/// Profile for mapping between Product entity and Product reponse types
/// </summary>
public class ProductProfiles : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProduct operations
    /// </summary>
    public ProductProfiles()
    {
        CreateMap<Product, ProductResult>();
        CreateMap<IEnumerable<Product>, List<ProductResult>>();
    }
}
