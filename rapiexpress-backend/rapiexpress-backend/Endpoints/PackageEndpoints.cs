using Application.Package.DTOs;
using Application.Package.Services;

namespace rapiexpress_backend.Endpoints;

public static class PackageEndpoints
{
    public static void MapPackageEndpoints(this WebApplication app)
    {
        app.MapPost("/packages/import", async (IEnumerable<PackageDto> packages, PackageService service) =>
        {
            await service.ImportAsync(packages);

            return Results.Ok(new { message = "Packages imported" });
        });
    }
}