using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branches.Common;

/// <summary>
/// Profile for mapping between Branch entity and Branch reponse types
/// </summary>
public class ItemSaleProfiles : Profile
{
    /// <summary>
    /// Initializes the mappings for GetBranch operations
    /// </summary>
    public ItemSaleProfiles()
    {
        CreateMap<ItemSale, BranchResult>();
        CreateMap<IEnumerable<Branch>, List<BranchResult>>();
    }
}
