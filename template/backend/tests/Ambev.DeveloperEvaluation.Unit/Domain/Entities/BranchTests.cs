using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Branch entity class.
/// Tests cover default values and property assignments.
/// </summary>
public class BranchTests
{
    /// <summary>
    /// Tests that a newly created branch has the correct default values.
    /// </summary>
    [Fact(DisplayName = "Newly created branch should have correct default values")]
    public void Given_NewBranch_When_Created_Then_ShouldHaveDefaultValues()
    {
        // Act
        var branch = new Branch();

        // Assert
        Assert.NotNull(branch.Name);
        Assert.Equal(string.Empty, branch.Name);
        Assert.Equal(0, branch.Code);
        Assert.Equal(BranchStatus.Active, branch.Status);
        Assert.NotEqual(DateTime.UtcNow, branch.CreatedAt);
        Assert.Null(branch.UpdatedAt);
    }

    /// <summary>
    /// Tests that branch properties can be correctly assigned.
    /// </summary>
    [Fact(DisplayName = "Branch properties should be correctly assigned")]
    public void Given_Branch_When_PropertiesAreSet_Then_ShouldReflectChanges()
    {
        // Arrange
        var branch = new Branch
        {
            Name = "Main Branch",
            Code = 1234
        };

        // Assert
        Assert.Equal("Main Branch", branch.Name);
        Assert.Equal(1234, branch.Code);
    }
}