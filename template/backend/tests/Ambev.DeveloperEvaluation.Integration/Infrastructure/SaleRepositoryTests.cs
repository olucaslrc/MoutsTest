using Xunit;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Integration.Infrastructure;

public class SaleRepositoryTests
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
    /// Test to verify if CreateAsync method adds a sale correctly
    /// </summary>
    [Fact]
    public async Task CreateAsync_Should_Add_Sale()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new SaleRepository(context);

        // Create a new sale with test values
        var sale = new Sale
        {
            CustomerId = Guid.NewGuid(),
            TotalAmount = 200.00m,
            Status = SaleStatus.Created,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Call the CreateAsync method to add the sale
        var createdSale = await repository.CreateAsync(sale);

        // Verify that the sale was added correctly
        Assert.NotNull(createdSale);
        Assert.Equal(sale.TotalAmount, createdSale.TotalAmount);
    }

    /// <summary>
    /// Test to verify if GetByIdAsync method returns a sale correctly
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_Should_Return_Sale()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new SaleRepository(context);

        // Create and add a sale to the context
        var sale = new Sale
        {
            CustomerId = Guid.NewGuid(),
            TotalAmount = 200.00m,
            Status = SaleStatus.Created,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.Sales.Add(sale);
        await context.SaveChangesAsync();

        // Call the GetByIdAsync method to get the sale by ID
        var retrievedSale = await repository.GetByIdAsync(sale.Id);

        // Verify that the sale was returned correctly
        Assert.NotNull(retrievedSale);
        Assert.Equal(sale.TotalAmount, retrievedSale.TotalAmount);
    }

    /// <summary>
    /// Test to verify if GetAllAsync method returns all sales correctly
    /// </summary>
    [Fact]
    public async Task GetAllAsync_Should_Return_All_Sales()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new SaleRepository(context);

        // Create and add multiple sales to the context
        var sale1 = new Sale
        {
            CustomerId = Guid.NewGuid(),
            TotalAmount = 200.00m,
            Status = SaleStatus.Created,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var sale2 = new Sale
        {
            CustomerId = Guid.NewGuid(),
            TotalAmount = 300.00m,
            Status = SaleStatus.Created,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.Sales.AddRange(sale1, sale2);
        await context.SaveChangesAsync();

        // Call the GetAllAsync method to get all sales
        var sales = await repository.GetAllAsync();

        // Verify that the sales were returned correctly
        Assert.NotNull(sales);
        Assert.Equal(2, sales.Count());
    }

    /// <summary>
    /// Test to verify if DeleteAsync method removes a sale correctly
    /// </summary>
    [Fact]
    public async Task DeleteAsync_Should_Remove_Sale()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new SaleRepository(context);

        // Create and add a sale to the context
        var sale = new Sale
        {
            CustomerId = Guid.NewGuid(),
            TotalAmount = 200.00m,
            Status = SaleStatus.Created,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.Sales.Add(sale);
        await context.SaveChangesAsync();

        // Call the DeleteAsync method to remove the sale by ID
        var result = await repository.DeleteAsync(sale.Id);

        // Verify that the sale was removed correctly
        Assert.True(result);
        var deletedSale = await repository.GetByIdAsync(sale.Id);
        Assert.Null(deletedSale);
    }
}
