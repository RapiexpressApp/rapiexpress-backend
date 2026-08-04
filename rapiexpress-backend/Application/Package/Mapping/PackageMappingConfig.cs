using Application.Package.DTOs;
using DomainPackage = Domain.Logistics.Entities.Package;
using Mapster;

namespace Application.Package.Mapping;

public sealed class PackageMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PackageDto, DomainPackage>();
    }
}