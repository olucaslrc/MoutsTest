using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Branch : BaseEntity
{
    /// <summary>
    /// Get branch name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the Branch current status.
    /// Indicates whether the item is added, modified, or cancelled in the system.
    /// </summary>
    public BranchStatus Status { get; set; }

    /// <summary>
    /// Get branch code
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Gets the date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the product's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
