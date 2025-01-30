using Xunit;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Integration.Infrastructure;

public class ProductRepositoryTests
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
    /// Test to verify if CreateAsync method adds a product correctly
    /// </summary>
    [Fact]
    public async Task CreateAsync_Should_Add_Product()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new ProductRepository(context);

        // Create a new product with test values
        var product = new Product
        {
            Name = "Test Product",
            UnitPrice = 10.00m,
            Status = ProductStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Call the CreateAsync method to add the product
        var createdProduct = await repository.CreateAsync(product);

        // Verify that the product was added correctly
        Assert.NotNull(createdProduct);
        Assert.Equal(product.Name, createdProduct.Name);
        Assert.Equal(product.UnitPrice, createdProduct.UnitPrice);
    }

    /// <summary>
    /// Test to verify if GetByIdAsync method returns a product correctly
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_Should_Return_Product()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new ProductRepository(context);

        // Create and add a product to the context
        var product = new Product
        {
            Name = "Test Product",
            UnitPrice = 10.00m,
            Status = ProductStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.Products.Add(product);
        await context.SaveChangesAsync();

        // Call the GetByIdAsync method to get the product by ID
        var retrievedProduct = await repository.GetByIdAsync(product.Id);

        // Verify that the product was returned correctly
        Assert.NotNull(retrievedProduct);
        Assert.Equal(product.Name, retrievedProduct.Name);
    }

    /// <summary>
    /// Test to verify if DeleteAsync method removes a product correctly
    /// </summary>
    [Fact]
    public async Task DeleteAsync_Should_Remove_Product()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new ProductRepository(context);

        // Create and add a product to the context
        var product = new Product
        {
            Name = "Test Product",
            UnitPrice = 10.00m,
            Status = ProductStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.Products.Add(product);
        await context.SaveChangesAsync();

        // Call the DeleteAsync method to remove the product by ID
        var result = await repository.DeleteAsync(product.Id);

        // Verify that the product was removed correctly
        Assert.True(result);
        var deletedProduct = await repository.GetByIdAsync(product.Id);
        Assert.Null(deletedProduct);
    }
}
