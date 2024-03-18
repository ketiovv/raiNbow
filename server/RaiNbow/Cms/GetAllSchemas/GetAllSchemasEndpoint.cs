using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using RaiNbow.Core.Storage;

namespace RaiNbow.Cms.GetAllSchemas;

internal static class GetAllSchemasEndpoint
{
    internal static IEndpointRouteBuilder UseGetAllSchemasEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/cms/schemas", async (RaiNbowContext context) =>
        {
            var schemas = await context.Schemas
                .Include(s => s.Fields)
                .ThenInclude(f => f.FieldType)
                .Select(s => SchemaDto.FromSchema(s))
                .ToListAsync();

            return schemas;
        }).WithTags("Schemas").RequireAuthorization();

        return endpoints;
    }
}