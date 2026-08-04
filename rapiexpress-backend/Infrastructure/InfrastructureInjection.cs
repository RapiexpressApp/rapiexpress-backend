using Infrastructure.DependencyInjection;
using Infrastructure.Persistence.logistics_db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInjection
{
    public static void AddInfrastucutre(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LogisticsDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("LogisticsDb")));
        services.AddRepositories();
    }
}