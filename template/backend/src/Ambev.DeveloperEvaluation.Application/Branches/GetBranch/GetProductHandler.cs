﻿using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Branches.Common;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch;

/// <summary>
/// Handler for processing GetBranchCommand requests.
/// </summary>
public class GetBranchHandler : IRequestHandler<GetBranchCommand, BranchResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="GetBranchHandler"/>.
    /// </summary>
    /// <param name="branchRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetBranchHandler(
        IBranchRepository branchRepository,
        IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetBranchCommand request.
    /// </summary>
    /// <param name="request">The GetBranch command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch details if found.</returns>
    public async Task<BranchResult> Handle(GetBranchCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetBranchValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var branch = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);
        if (branch == null)
            throw new KeyNotFoundException($"Branch with ID {request.Id} not found");

        return _mapper.Map<BranchResult>(branch);
    }
}
