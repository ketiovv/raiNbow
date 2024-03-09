using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RaiNbow.Core.Storage;

namespace RaiNbow.Cms.CreateSchema;

internal static class CreateSchemaEndpoint
{
    internal static IEndpointRouteBuilder UseCreateSchemaEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/cms/schemas", async (
                RaiNbowContext context,
                CreateSchemaRequest request) =>
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    throw new Exception("Name of the schema must be specified.");
                }


                var schema = new Schema
                {
                    Name = request.Name,
                    Fields = request.Fields.Select(f => new Field
                    {
                        Name = f.Name,
                        FieldTypeId = f.FieldTypeId
                    }).ToList()
                };

                await context.Schemas.AddAsync(schema);
                await context.SaveChangesAsync();
            }).WithTags("Schemas").RequireAuthorization();

        return endpoints;
    }
}