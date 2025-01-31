using Ambev.DeveloperEvaluation.Application.Branches.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch;

/// <summary>
/// Represents the command to retrieve a branch by its ID.
/// </summary>
public class GetBranchCommand : IRequest<BranchResult>
{
    /// <summary>
    /// Gets the unique identifier of the branch.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetBranchCommand"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the branch.</param>
    public GetBranchCommand(Guid id)
    {
        Id = id;
    }
}
