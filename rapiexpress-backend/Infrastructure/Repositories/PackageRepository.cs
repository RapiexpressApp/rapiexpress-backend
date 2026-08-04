using Application.Package.Interfaces;
using Domain.Logistics.Entities;
using Infrastructure.Persistence.logistics_db;

namespace Infrastructure.Repositories;

public sealed class PackageRepository(LogisticsDbContext dbContext) : IPackageRepository
{
    public async Task AddRangeAsync(IEnumerable<Package> packages) => await dbContext.Packages.AddRangeAsync(packages);

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
}
