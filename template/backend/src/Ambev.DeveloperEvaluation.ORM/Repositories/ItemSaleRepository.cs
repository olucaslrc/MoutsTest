using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IItemSaleRepository using Entity Framework Core
/// </summary>
public class ItemSaleRepository : IItemSaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of ItemSaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ItemSaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new item sale in the database
    /// </summary>
    /// <param name="itemSale">The item sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created item sale</returns>
    public async Task<ItemSale> CreateAsync(ItemSale itemSale, CancellationToken cancellationToken = default)
    {
        await _context.ItemSales.AddAsync(itemSale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return itemSale;
    }

    /// <summary>
    /// Retrieves an item sale by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the item sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The item sale if found, null otherwise</returns>
    public async Task<ItemSale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ItemSales.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves all item sales for a given sale ID
    /// </summary>
    /// <param name="saleId">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of item sales</returns>
    public async Task<IEnumerable<ItemSale>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default)
    {
        return await _context.ItemSales.Where(i => i.SaleId == saleId).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes an item sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the item sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the item sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var itemSale = await GetByIdAsync(id, cancellationToken);
        if (itemSale == null)
            return false;

        _context.ItemSales.Remove(itemSale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
