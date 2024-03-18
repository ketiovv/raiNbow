using Microsoft.AspNetCore.Routing;
using RaiNbow.Cms.CreateSchema;
using RaiNbow.Cms.GetAllSchemas;

namespace RaiNbow.Cms;

internal static class Configuration
{
    internal static IEndpointRouteBuilder UseCmsEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints
            .UseCreateSchemaEndpoint()
            .UseGetAllSchemasEndpoint();
}