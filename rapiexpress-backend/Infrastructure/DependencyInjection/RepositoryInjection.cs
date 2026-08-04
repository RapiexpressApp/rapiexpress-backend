using Application.Package.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class RepositoryInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPackageRepository, IPackageRepository>();
    }
}