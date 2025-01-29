using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    /// <summary>
    /// Get product name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Get product unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Get status product
    /// </summary>
    public ProductStatus Status { get; set; }

    /// <summary>
    /// Gets the date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the product's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void SetStatus(ProductStatus status)
    {
        Status = status;
    }

}
