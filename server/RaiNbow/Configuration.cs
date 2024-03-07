using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RaiNbow.Cms;
using RaiNbow.Core.Storage;

namespace RaiNbow;

public static class Configuration
{
    public static IServiceCollection AddRaiNbowServices(this IServiceCollection services)
    {
        services.AddDbContext<RaiNbowContext>(options =>
            options.UseNpgsql("name=Postgres"));

        return services;
    }

    public static IEndpointRouteBuilder UseRaiNbowEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints.UseCmsEndpoints();
}