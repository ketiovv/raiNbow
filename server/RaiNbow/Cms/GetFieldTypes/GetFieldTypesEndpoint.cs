using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using RaiNbow.Cms.GetAllSchemas;
using RaiNbow.Core.Storage;

namespace RaiNbow.Cms.GetFieldTypes;

internal static class GetFieldTypesEndpoint
{
    internal static IEndpointRouteBuilder UseGetFieldTypesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/cms/fieldTypes", async (RaiNbowContext context) =>
        {
            var schemas = await context.FieldType
                .Select(ft => FieldTypeDto.FromFieldType(ft))
                .ToListAsync();

            return schemas;
        }).WithTags("FieldTypes").RequireAuthorization();

        return endpoints;
    }
}