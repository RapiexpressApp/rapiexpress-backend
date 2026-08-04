using DependencyInjection;
using Infrastructure.Persistence.logistics_db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucutre(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LogisticsDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("LogisticsDb")));
        
        services.AddRepositories();
        
        
        return services;
    }
}