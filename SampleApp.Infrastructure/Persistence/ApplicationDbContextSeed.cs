
using SampleApp.Domain.Entities;
using SampleApp.Domain.Enums;

namespace SampleApp.Infrastructure.Persistence;

public class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User
                {
                    Name = "Admin",
                    UserType = UserType.Administrator
                },
                new User
                {
                    Name = "Manager 1",
                    UserType = UserType.Manager
                },
                new User
                {
                    Name = "Customer 1",
                    UserType = UserType.Customer
                },
                new User
                {
                    Name = "Customer 2",
                    UserType = UserType.Customer
                },
                new User
                {
                    Name = "Customer 3",
                    UserType = UserType.Customer
                },
                new User
                {
                    Name = "Customer 4",
                    UserType = UserType.Customer
                },
                new User
                {
                    Name = "Customer 5",
                    UserType = UserType.Customer
                },
                new User
                {
                    Name = "Customer 6",
                    UserType = UserType.Customer
                },
                new User
                {
                    Name = "Customer 7",
                    UserType = UserType.Customer
                },
                new User
                {
                    Name = "Customer 8",
                    UserType = UserType.Customer
                });
            await context.SaveChangesAsync();
        }
    }
}

