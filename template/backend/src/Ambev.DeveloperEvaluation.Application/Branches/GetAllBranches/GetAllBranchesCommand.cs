using Ambev.DeveloperEvaluation.Application.Branches.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetAllBranches;

/// <summary>
/// Represents the command to retrieve all branches.
/// </summary>
public class GetAllBranchesCommand : IRequest<List<BranchResult>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllBranchesCommand"/> class.
    /// </summary>
    public GetAllBranchesCommand()
    {
    }
}
