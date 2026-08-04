namespace Application.Package.Interfaces;

public interface IPackageRepository
{
    Task AddRangeAsync(IEnumerable<Domain.Logistics.Entities.Package> packages);
    Task SaveChangesAsync();
}                                                                                           