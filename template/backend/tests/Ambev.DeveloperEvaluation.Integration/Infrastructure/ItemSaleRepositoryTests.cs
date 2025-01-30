using Xunit;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Integration.Infrastructure;

public class ItemSaleRepositoryTests
{
    /// <summary>
    /// Method to configure DbContext options using an in-memory database for testing
    /// </summary>
    private DbContextOptions<DefaultContext> GetInMemoryOptions()
    {
        return new DbContextOptionsBuilder<DefaultContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Uses a unique in-memory database for each test
            .Options;
    }

    /// <summary>
    /// Test to verify if CreateAsync method adds an item sale correctly
    /// </summary>
    [Fact]
    public async Task CreateAsync_Should_Add_ItemSale()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new ItemSaleRepository(context);

        // Create a new item sale with test values
        var itemSale = new ItemSale
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 10,
            TotalAmount = 100.00m,
            Status = ItemSaleStatus.Added,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Call the CreateAsync method to add the item sale
        var createdItemSale = await repository.CreateAsync(itemSale);

        // Verify that the item sale was added correctly
        Assert.NotNull(createdItemSale);
        Assert.Equal(itemSale.Quantity, createdItemSale.Quantity);
        Assert.Equal(itemSale.TotalAmount, createdItemSale.TotalAmount);
    }

    /// <summary>
    /// Test to verify if GetByIdAsync method returns an item sale correctly
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_Should_Return_ItemSale()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new ItemSaleRepository(context);

        // Create and add an item sale to the context
        var itemSale = new ItemSale
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 10,
            TotalAmount = 100.00m,
            Status = ItemSaleStatus.Added,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.ItemSales.Add(itemSale);
        await context.SaveChangesAsync();

        // Call the GetByIdAsync method to get the item sale by ID
        var retrievedItemSale = await repository.GetByIdAsync(itemSale.Id);

        // Verify that the item sale was returned correctly
        Assert.NotNull(retrievedItemSale);
        Assert.Equal(itemSale.Quantity, retrievedItemSale.Quantity);
    }

    /// <summary>
    /// Test to verify if GetBySaleIdAsync method returns all item sales for a given sale ID correctly
    /// </summary>
    [Fact]
    public async Task GetBySaleIdAsync_Should_Return_All_ItemSales_For_Sale()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new ItemSaleRepository(context);

        var saleId = Guid.NewGuid();

        // Create and add multiple item sales to the context
        var itemSale1 = new ItemSale
        {
            SaleId = saleId,
            ProductId = Guid.NewGuid(),
            Quantity = 10,
            TotalAmount = 100.00m,
            Status = ItemSaleStatus.Added,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var itemSale2 = new ItemSale
        {
            SaleId = saleId,
            ProductId = Guid.NewGuid(),
            Quantity = 5,
            TotalAmount = 50.00m,
            Status = ItemSaleStatus.Added,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.ItemSales.AddRange(itemSale1, itemSale2);
        await context.SaveChangesAsync();

        // Call the GetBySaleIdAsync method to get all item sales for the sale ID
        var itemSales = await repository.GetBySaleIdAsync(saleId);

        // Verify that the item sales were returned correctly
        Assert.NotNull(itemSales);
        Assert.Equal(2, itemSales.Count());
    }

    /// <summary>
    /// Test to verify if DeleteAsync method removes an item sale correctly
    /// </summary>
    [Fact]
    public async Task DeleteAsync_Should_Remove_ItemSale()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new ItemSaleRepository(context);

        // Create and add an item sale to the context
        var itemSale = new ItemSale
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 10,
            TotalAmount = 100.00m,
            Status = ItemSaleStatus.Added,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.ItemSales.Add(itemSale);
        await context.SaveChangesAsync();

        // Call the DeleteAsync method to remove the item sale by ID
        var result = await repository.DeleteAsync(itemSale.Id);

        // Verify that the item sale was removed correctly
        Assert.True(result);
        var deletedItemSale = await repository.GetByIdAsync(itemSale.Id);
        Assert.Null(deletedItemSale);
    }
}
