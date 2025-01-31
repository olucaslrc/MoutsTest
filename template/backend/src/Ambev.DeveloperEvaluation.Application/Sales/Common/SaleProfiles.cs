using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common;

/// <summary>
/// Profile for mapping between Branch entity and Branch reponse types
/// </summary>
public class SaleProfiles : Profile
{
    /// <summary>
    /// Initializes the mappings for GetBranch operations
    /// </summary>
    public SaleProfiles()
    {
        CreateMap<Sale, SaleResult>();
        CreateMap<IEnumerable<Sale>, List<SaleResult>>();
    }
}
