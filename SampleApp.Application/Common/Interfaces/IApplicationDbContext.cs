using Microsoft.EntityFrameworkCore;
using SampleApp.Domain.Entities;

namespace SampleApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
