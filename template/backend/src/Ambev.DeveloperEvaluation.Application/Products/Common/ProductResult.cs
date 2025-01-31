namespace Ambev.DeveloperEvaluation.Application.Products.Common;

public class ProductResult
{
    /// <summary>
    /// Unique identifier of the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; } = default;

    /// <summary>
    /// Date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = default;

    /// <summary>
    /// Date and time of the last update of the product.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = default;
}
