using Domain.Logistics.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IPackage
{
    Task AddRangeAsync(IEnumerable<Package> packages);
    Task SaveChangesAsync();
}                                                                                           