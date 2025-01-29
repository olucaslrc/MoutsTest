using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemSale : BaseEntity
{
    /// <summary>
    /// Gets the sales's unique ID.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the product's unique ID.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the specified quantity of product for sale
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the Amount from ItemSale by product quantity
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets the itemSales's current status.
    /// Indicates whether the item is added, modified, or cancelled in the system.
    /// </summary>
    public ItemSaleStatus Status { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the sales's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public ItemSale()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Set status of ItemSale
    /// </summary>
    /// <param name="status"></param>
    public void SetStatus(ItemSaleStatus status)
    {
        Status = status;
    }
}
