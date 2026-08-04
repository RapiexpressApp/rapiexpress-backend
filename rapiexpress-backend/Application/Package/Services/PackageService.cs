using Application.Package.DTOs;
using DomainPackage = Domain.Logistics.Entities.Package;
using Application.Package.Interfaces;
using Mapster;

namespace Application.Package.Services;

public sealed class PackageService(IPackageRepository repository)
{
    public async Task ImportAsync(IEnumerable<PackageDto> packages)
    {
        var entities = packages.Adapt<List<DomainPackage>>();

        await repository.AddRangeAsync(entities);
        await repository.SaveChangesAsync();
    }
}