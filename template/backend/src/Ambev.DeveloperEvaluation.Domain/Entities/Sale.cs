using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the sales's customer unique ID.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets the itens from this sale
    /// </summary>
    public List<ItemSale> ItensSales { get; set; } = [];

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

    ///// <summary>
    ///// Gets the unique identifier of the sale.
    ///// </summary>
    ///// <returns>The sales's ID as a string.</returns>
    //string ISale.Id => Id.ToString();

    ///// <summary>
    ///// Gets the sale customer username.
    ///// </summary>
    ///// <returns>The username of sale customer.</returns>
    //string ISale.Customer => Customer.Username;

    ///// <summary>
    ///// Gets the sale status.
    ///// </summary>
    ///// <returns>The sale status.</returns>
    //string ISale.Status => Status.ToString();

    //public Sale(User customer)
    //{
    //    if (customer.Role != UserRole.Customer)
    //        throw new DomainException("Only users with role 'Customer' can be assined as a customer.");

    //    CustomerId = customer.Id;
    //    Customer = customer;
    //    CreatedAt = DateTime.UtcNow;
    //}

    /// <summary>
    /// Set the status of sales
    /// </summary>
    /// <param name="status"></param>
    public void SetStatus(SaleStatus status)
    {
        Status = status;
    }
}


