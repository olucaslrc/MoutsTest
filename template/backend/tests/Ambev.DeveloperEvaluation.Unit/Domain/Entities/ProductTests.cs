using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Product entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class ProductTests
{
    /// <summary>
    /// Tests that when a product status is changed, it updates correctly.
    /// </summary>
    [Fact(DisplayName = "Product status should change correctly when SetStatus is called")]
    public void Given_Product_When_SetStatusIsCalled_Then_StatusShouldChange()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        var newStatus = product.Status == ProductStatus.Active ? ProductStatus.Inactive : ProductStatus.Active;

        // Act
        product.SetStatus(newStatus);

        // Assert
        Assert.Equal(newStatus, product.Status);
    }

    /// <summary>
    /// Tests that a newly created product has the correct default properties.
    /// </summary>
    [Fact(DisplayName = "Newly created product should have correct default values")]
    public void Given_NewProduct_When_Created_Then_ShouldHaveDefaultValues()
    {
        // Act
        var product = new Product();

        // Assert
        Assert.Equal(string.Empty, product.Name);
        Assert.Equal(0m, product.UnitPrice);
        Assert.Equal(ProductStatus.Active, product.Status);
        Assert.NotEqual(default, product.CreatedAt);
        Assert.Null(product.UpdatedAt);
    }
}
