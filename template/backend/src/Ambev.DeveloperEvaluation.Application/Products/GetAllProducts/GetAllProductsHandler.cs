﻿using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

/// <summary>
/// Handler for processing GetAllProductsCommand requests.
/// </summary>
public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, List<ProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="GetAllProductsHandler"/>.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetAllProductsHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetAllProductsCommand request.
    /// </summary>
    /// <param name="request">The GetAllProducts command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of all products.</returns>
    public async Task<List<ProductResult>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ProductResult>>(products);
    }
}
