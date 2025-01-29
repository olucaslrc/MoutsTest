using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the ItemSale entity class.
    /// Tests cover status changes and validation scenarios.
    /// </summary>
    public class ItemSaleTests
    {
        /// <summary>
        /// Tests that when an item sale status is changed, it updates correctly.
        /// </summary>
        [Fact(DisplayName = "ItemSale status should change correctly when SetStatus is called")]
        public void Given_ItemSale_When_SetStatusIsCalled_Then_StatusShouldChange()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var product = ProductTestData.GenerateValidProduct();
            var itemSale = ItemSaleTestData.GenerateValidItemSale();
            var newStatus = ItemSaleTestData.GenerateRandomItemSaleStatus();

            // Act
            itemSale.SetStatus(newStatus);

            // Assert
            Assert.Equal(newStatus, itemSale.Status);
        }

        /// <summary>
        /// Tests that a newly created item sale has the correct default properties.
        /// </summary>
        [Fact(DisplayName = "Newly created ItemSale should have correct default values")]
        public void Given_NewItemSale_When_Created_Then_ShouldHaveDefaultValues()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale(); // Assuming SaleTestData exists for generating Sale
            var product = ProductTestData.GenerateValidProduct();

            // Act
            var itemSale = ItemSaleTestData.GenerateValidItemSale();
            itemSale.SaleId = sale.Id;
            itemSale.ProductId = product.Id;

            // Assert
            Assert.Equal(sale.Id, itemSale.SaleId);
            Assert.Equal(product.Id, itemSale.ProductId);
            Assert.NotEqual(0, itemSale.Quantity);
            Assert.NotEqual(0m, itemSale.TotalAmount);
            Assert.Contains(itemSale.Status, new[] { ItemSaleStatus.Added, ItemSaleStatus.Cancelled, ItemSaleStatus.Modified });
            Assert.NotEqual(default, itemSale.CreatedAt);
            Assert.Null(itemSale.UpdatedAt);
        }
    }
}
