using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated products will have valid:
    /// - Name (random product name)
    /// - Price (valid positive value)
    /// - Status (Active or Inactive)
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
        .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(1, 1000))
        .RuleFor(p => p.Status, f => f.PickRandom(ProductStatus.Active, ProductStatus.Inactive));

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid product name.
    /// </summary>
    /// <returns>A valid product name.</returns>
    public static string GenerateValidProductName()
    {
        return new Faker().Commerce.ProductName();
    }

    /// <summary>
    /// Generates a valid price.
    /// </summary>
    /// <returns>A valid price value.</returns>
    public static decimal GenerateValidPrice()
    {
        return new Faker().Random.Decimal(1, 1000);
    }

    /// <summary>
    /// Generates an invalid price (negative value).
    /// </summary>
    /// <returns>An invalid price value.</returns>
    public static decimal GenerateInvalidPrice()
    {
        return new Faker().Random.Decimal(-1000, -1);
    }
}