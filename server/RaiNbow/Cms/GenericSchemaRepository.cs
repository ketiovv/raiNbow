using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RaiNbow.Core.Storage;

namespace RaiNbow.Cms;

public class GenericSchemaRepository : IGenericSchemaRepository
{
    private readonly RaiNbowContext _context;

    public GenericSchemaRepository(RaiNbowContext context)
    {
        _context = context;
    }
    public async Task<string> GetAllAsJsonAsync(string schemaName)
    {
        var schema = await _context.Schemas
            .Include(s => s.Fields)
            .SingleOrDefaultAsync(x => x.Name.Equals(schemaName));
        if (schema is null)
        {
            throw new Exception($"Cannot find schema with name {schemaName}");
        }

        var fields = schema.Fields.Select(f => f.Name);
        var fieldsString = string.Join(",", fields);
        var sql = $"SELECT {fieldsString} FROM {schemaName}";

        var results = await _context.Database.SqlQueryRaw<object>(sql).ToListAsync();
        var jsonString = JsonSerializer.Serialize(results);

        return jsonString;
    }
}