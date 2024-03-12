using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        services.AddAuthorization();
        services.AddAuthentication();
        
        services
            .AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<RaiNbowContext>();

        return services;
    }
    
    private static IEndpointRouteBuilder UseRaiNbowEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints.UseCmsEndpoints();

    public static IApplicationBuilder UseRaiNbow(this WebApplication app)
    {
        app.UseAuthorization();
        
        app.UseRaiNbowEndpoints();
        app.MapIdentityApi<IdentityUser>().WithTags("Auth");

        return app;
    }
}