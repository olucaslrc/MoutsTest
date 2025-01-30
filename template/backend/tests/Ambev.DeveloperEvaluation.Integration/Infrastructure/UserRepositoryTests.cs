using Xunit;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Integration.Infrastructure;

public class UserRepositoryTests
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
    /// Test to verify if CreateAsync method adds a user correctly
    /// </summary>
    [Fact]
    public async Task CreateAsync_Should_Add_User()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new UserRepository(context);

        // Create a new user with test values
        var user = new User
        {
            Email = "test@example.com",
            Password = "password",
            Username = "testuser",
            Role = UserRole.Admin,
            Status = UserStatus.Unknown,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Call the CreateAsync method to add the user
        var createdUser = await repository.CreateAsync(user);

        // Verify that the user was added correctly
        Assert.NotNull(createdUser);
        Assert.Equal(user.Email, createdUser.Email);
        Assert.Equal(user.Username, createdUser.Username);
    }

    /// <summary>
    /// Test to verify if GetByIdAsync method returns a user correctly
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_Should_Return_User()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new UserRepository(context);

        // Create and add a user to the context
        var user = new User
        {
            Email = "test@example.com",
            Password = "password",
            Username = "testuser",
            Role = UserRole.Manager,
            Status = UserStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Call the GetByIdAsync method to get the user by ID
        var retrievedUser = await repository.GetByIdAsync(user.Id);

        // Verify that the user was returned correctly
        Assert.NotNull(retrievedUser);
        Assert.Equal(user.Email, retrievedUser.Email);
    }

    /// <summary>
    /// Test to verify if GetByEmailAsync method returns a user correctly by email
    /// </summary>
    [Fact]
    public async Task GetByEmailAsync_Should_Return_User()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new UserRepository(context);

        // Create and add a user to the context
        var user = new User
        {
            Email = "test@example.com",
            Password = "password",
            Username = "testuser",
            Role = UserRole.None,
            Status = UserStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Call the GetByEmailAsync method to get the user by email
        var retrievedUser = await repository.GetByEmailAsync(user.Email);

        // Verify that the user was returned correctly
        Assert.NotNull(retrievedUser);
        Assert.Equal(user.Email, retrievedUser.Email);
    }

    /// <summary>
    /// Test to verify if DeleteAsync method removes a user correctly
    /// </summary>
    [Fact]
    public async Task DeleteAsync_Should_Remove_User()
    {
        var options = GetInMemoryOptions();
        using var context = new DefaultContext(options);
        var repository = new UserRepository(context);

        // Create and add a user to the context
        var user = new User
        {
            Email = "test@example.com",
            Password = "password",
            Username = "testuser",
            Role = UserRole.Customer,
            Status = UserStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Call the DeleteAsync method to remove the user by ID
        var result = await repository.DeleteAsync(user.Id);

        // Verify that the user was removed correctly
        Assert.True(result);
        var deletedUser = await repository.GetByIdAsync(user.Id);
        Assert.Null(deletedUser);
    }
}
