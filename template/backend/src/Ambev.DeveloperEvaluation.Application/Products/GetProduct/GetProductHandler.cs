﻿using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Handler for processing GetProductCommand requests.
/// </summary>
public class GetProductHandler : IRequestHandler<GetProductCommand, ProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="GetProductHandler"/>.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetProductHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductCommand request.
    /// </summary>
    /// <param name="request">The GetProduct command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The product details if found.</returns>
    public async Task<ProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found");

        return _mapper.Map<ProductResult>(product);
    }
}
