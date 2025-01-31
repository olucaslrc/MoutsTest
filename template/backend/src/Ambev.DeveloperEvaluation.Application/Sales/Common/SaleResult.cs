using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common;
public class SaleResult
{
    /// <summary>
    /// Gets the sales's customer unique ID.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets the itens from this sale
    /// </summary>
    public List<ItemSale> ItensSale { get; set; } = [];

    /// <summary>
    /// Gets the sales's current status.
    /// Indicates whether the sale is created, modified, or cancelled in the system.
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Gets the total sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the sales's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}

