using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
}