using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class SaleTestData
{
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.CustomerId, f => Guid.NewGuid()) // Generate a random CustomerId
        .RuleFor(s => s.Status, f => f.PickRandom(SaleStatus.Created, SaleStatus.Modified, SaleStatus.Cancelled)) // Pick a random SaleStatus
        .RuleFor(s => s.TotalAmount, f => f.Random.Decimal(100, 10000)) // Generate a random TotalAmount between 100 and 10000
        .RuleFor(s => s.CreatedAt, f => f.Date.Past()) // Generate a random past date for CreatedAt
        .RuleFor(s => s.UpdatedAt, f => f.Date.Recent()); // Generate a random recent date for UpdatedAt

    /// <summary>
    /// Generates a valid Sale entity with randomized data and a valid Customer.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        return SaleFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Sale status.
    /// </summary>
    /// <returns>A random SaleStatus value.</returns>
    public static SaleStatus GenerateValidStatus()
    {
        return new Faker().PickRandom<SaleStatus>();
    }

    /// <summary>
    /// Generates a valid TotalAmount for Sale.
    /// </summary>
    /// <returns>A valid TotalAmount value.</returns>
    public static decimal GenerateValidTotalAmount()
    {
        return new Faker().Random.Decimal(100, 10000);
    }
}
