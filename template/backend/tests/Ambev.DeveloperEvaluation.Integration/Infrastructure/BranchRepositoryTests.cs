using Xunit;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Integration.Infrastructure;

public class BranchRepositoryTests
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
    /// Test to verify if CreateAsync method adds a branch correctly
    /// </summary>
    [Fact]
    public async Task CreateAsync_Should_Add_Branch()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new BranchRepository(context);

        // Create a new branch with test values
        var branch = new Branch
        {
            Name = "Test Branch",
            Code = 123,
            Status = BranchStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Call the CreateAsync method to add the branch
        var createdBranch = await repository.CreateAsync(branch);

        // Verify that the branch was added correctly
        Assert.NotNull(createdBranch);
        Assert.Equal(branch.Name, createdBranch.Name);
        Assert.Equal(branch.Code, createdBranch.Code);
    }

    /// <summary>
    /// Test to verify if GetByIdAsync method returns a branch correctly
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_Should_Return_Branch()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new BranchRepository(context);

        // Create and add a branch to the context
        var branch = new Branch
        {
            Name = "Test Branch",
            Code = 123,
            Status = BranchStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.Branches.Add(branch);
        await context.SaveChangesAsync();

        // Call the GetByIdAsync method to get the branch by ID
        var retrievedBranch = await repository.GetByIdAsync(branch.Id);

        // Verify that the branch was returned correctly
        Assert.NotNull(retrievedBranch);
        Assert.Equal(branch.Name, retrievedBranch.Name);
    }

    /// <summary>
    /// Test to verify if DeleteAsync method removes a branch correctly
    /// </summary>
    [Fact]
    public async Task DeleteAsync_Should_Remove_Branch()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new BranchRepository(context);

        // Create and add a branch to the context
        var branch = new Branch
        {
            Name = "Test Branch",
            Code = 123,
            Status = BranchStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.Branches.Add(branch);
        await context.SaveChangesAsync();

        // Call the DeleteAsync method to remove the branch by ID
        var result = await repository.DeleteAsync(branch.Id);

        // Verify that the branch was removed correctly
        Assert.True(result);
        var deletedBranch = await repository.GetByIdAsync(branch.Id);
        Assert.Null(deletedBranch);
    }
}
