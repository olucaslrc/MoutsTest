using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for ItemSale entity operations
/// </summary>
public interface IItemSaleRepository
{
    /// <summary>
    /// Creates a new item sale in the repository
    /// </summary>
    /// <param name="itemSale">The item sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created item sale</returns>
    Task<ItemSale> CreateAsync(ItemSale itemSale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an item sale by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the item sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The item sale if found, null otherwise</returns>
    Task<ItemSale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all item sales for a given sale ID
    /// </summary>
    /// <param name="saleId">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of item sales</returns>
    Task<IEnumerable<ItemSale>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an item sale from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the item sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the item sale was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
