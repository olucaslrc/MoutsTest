using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;
public class SaleTests
{
    /// <summary>
    /// Test if generating a valid sale with a customer works correctly.
    /// </summary>
    [Fact]
    public void GenerateValidSale_ShouldReturnSaleWithValidData()
    {
        // Arrange: Create a valid customer
        var customer = UserTestData.GenerateValidUser();

        // Act: Generate a valid sale using the SaleTestData
        // Using explicit atributes to sale
        var sale = SaleTestData.GenerateValidSale();
        sale.CustomerId = customer.Id;

        // Assert: Verify the sale has a valid customer and status
        Assert.Equal(customer.Id, sale.CustomerId);
        Assert.InRange(sale.TotalAmount, 100, 10000);
        Assert.True(sale.CreatedAt < DateTime.UtcNow);
        Assert.True(sale.UpdatedAt <= DateTime.UtcNow);
        Assert.True(Enum.IsDefined(typeof(SaleStatus), sale.Status));
    }

    /// <summary>
    /// Test if generating a valid SaleStatus works correctly.
    /// </summary>
    [Fact]
    public void GenerateValidStatus_ShouldReturnValidSaleStatus()
    {
        // Act: Generate a valid sale status
        var saleStatus = SaleTestData.GenerateValidStatus();

        // Assert: Verify that the sale status is one of the defined enum values
        Assert.True(Enum.IsDefined(typeof(SaleStatus), saleStatus));
    }

    /// <summary>
    /// Test if generating a valid TotalAmount works correctly.
    /// </summary>
    [Fact]
    public void GenerateValidTotalAmount_ShouldReturnValidTotalAmount()
    {
        // Act: Generate a valid total amount for a sale
        var totalAmount = SaleTestData.GenerateValidTotalAmount();

        // Assert: Verify that the total amount is within the expected range
        Assert.InRange(totalAmount, 100, 10000);
    }

    /// <summary>
    /// Test if the Sale's status is picked randomly from the possible SaleStatus values.
    /// </summary>
    [Fact]
    public void GenerateValidSale_ShouldPickRandomStatus()
    {
        // Arrange: Create a valid customer
        var customer = UserTestData.GenerateValidUser();
        customer.Role = UserRole.Customer;

        // Act: Generate a valid sale
        var sale = SaleTestData.GenerateValidSale();

        // Assert: Verify that the status is one of the predefined values
        Assert.True(Enum.IsDefined(typeof(SaleStatus), sale.Status));
    }
}
