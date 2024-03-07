using Microsoft.AspNetCore.Routing;
using RaiNbow.Cms.CreateSchema;

namespace RaiNbow.Cms;

internal static class Configuration
{
    internal static IEndpointRouteBuilder UseCmsEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints.UseCreateSchemaEndpoint();
}