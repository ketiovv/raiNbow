using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using RaiNbow.Cms.CreateSchema;
using RaiNbow.Cms.GetAllSchemas;

namespace RaiNbow.Cms;

internal static class Configuration
{
    internal static IServiceCollection AddCmsServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericSchemaRepository, GenericSchemaRepository>();
        
        return services;
    }

    internal static IEndpointRouteBuilder UseCmsEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints
            .UseCreateSchemaEndpoint()
            .UseGetAllSchemasEndpoint();
}