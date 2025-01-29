using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data for the Branch entity.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class BranchTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Branch entities.
    /// The generated branches will have valid:
    /// - Name (randomized text)
    /// - Code (random number within a valid range)
    /// </summary>
    private static readonly Faker<Branch> BranchFaker = new Faker<Branch>()
        .RuleFor(b => b.Name, f => f.Company.CompanyName())
        .RuleFor(b => b.Code, f => f.Random.Int(1000, 9999));

    /// <summary>
    /// Generates a valid Branch entity with randomized data.
    /// </summary>
    /// <returns>A valid Branch entity.</returns>
    public static Branch GenerateValidBranch()
    {
        return BranchFaker.Generate();
    }

    /// <summary>
    /// Generates an invalid Branch entity with missing or incorrect values.
    /// </summary>
    /// <returns>An invalid Branch entity.</returns>
    public static Branch GenerateInvalidBranch()
    {
        return new Branch
        {
            Name = string.Empty, // Invalid empty name
            Code = -1 // Invalid negative code
        };
    }
}