using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library for ItemSale entities.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios for ItemSale.
/// </summary>
public static class ItemSaleTestData
{
    private static readonly Faker<ItemSale> ItemSaleFaker = new Faker<ItemSale>()
        .RuleFor(i => i.SaleId, f => Guid.NewGuid()) // Generate a random SaleId (Guid)
        .RuleFor(i => i.ProductId, f => Guid.NewGuid()) // Generate a random ProductId (Guid)
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 100)) // Generate a random quantity between 1 and 100
        .RuleFor(i => i.TotalAmount, (f, i) => i.Quantity * f.Random.Decimal(1, 1000)) // Calculate TotalAmount based on quantity and random price
        .RuleFor(i => i.Status, f => f.PickRandom(ItemSaleStatus.Added, ItemSaleStatus.Modified, ItemSaleStatus.Cancelled)) // Pick a random status
        .RuleFor(i => i.CreatedAt, f => f.Date.Past()) // Generate a random past date for CreatedAt
        .RuleFor(i => i.UpdatedAt, (f, i) => i.Status == ItemSaleStatus.Modified ? f.Date.Recent() : null); // If modified, set UpdatedAt to recent date

    /// <summary>
    /// Generates a valid ItemSale entity with randomized data.
    /// </summary>
    /// <returns>A valid ItemSale entity with randomly generated data.</returns>
    public static ItemSale GenerateValidItemSale()
    {
        return ItemSaleFaker.Generate();
    }

    /// <summary>
    /// Generates a valid quantity value for ItemSale.
    /// </summary>
    /// <returns>A valid quantity value.</returns>
    public static int GenerateValidQuantity()
    {
        return new Faker().Random.Int(1, 100);
    }

    /// <summary>
    /// Generates a valid total amount for ItemSale based on quantity and price.
    /// </summary>
    /// <returns>A valid total amount value.</returns>
    public static decimal GenerateValidTotalAmount(int quantity)
    {
        return new Faker().Random.Decimal(1, 1000) * quantity;
    }

    /// <summary>
    /// Generates an invalid quantity (negative value).
    /// </summary>
    /// <returns>An invalid quantity value.</returns>
    public static int GenerateInvalidQuantity()
    {
        return new Faker().Random.Int(-100, -1);
    }

    /// <summary>
    /// Generates an invalid total amount (negative value).
    /// </summary>
    /// <returns>An invalid total amount value.</returns>
    public static decimal GenerateInvalidTotalAmount()
    {
        return new Faker().Random.Decimal(-1000, -1);
    }

    public static ItemSaleStatus GenerateRandomItemSaleStatus()
    {
        return ItemSaleFaker.Generate().Status;
    }
}
