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
        var schema = await GetSchemaByName(schemaName);
        var fieldsString = GetFieldsString(schema);
        
        var sql = $"SELECT {fieldsString} FROM {schemaName}";
        var results = await _context.Database.SqlQueryRaw<object>(sql).ToListAsync();
        
        var jsonString = JsonSerializer.Serialize(results);
        return jsonString;
    }

    public async Task<string> GetByIdAsJsonAsync(string schemaName, Guid recordId)
    {
        var schema = await GetSchemaByName(schemaName);
        var fieldsString = GetFieldsString(schema);

        var sql = $"SELECT {fieldsString} FROM {schemaName} WHERE {StorageConstants.IdFieldName} = {recordId}";
        var result = await _context.Database.SqlQueryRaw<object>(sql).SingleOrDefaultAsync();
        if (result is null)
        {
            throw new Exception($"Record with {recordId} was not found in the {schemaName} table.");
        }
        
        var jsonString = JsonSerializer.Serialize(result);
        return jsonString;
    }

    public Task AddAsync(string schemaName, string json)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string schemaName, Guid recordId, string json)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string schemaName, Guid recordId)
    {
        throw new NotImplementedException();
    }


    private async Task<Schema> GetSchemaByName(string schemaName)
    {
        var schema = await _context.Schemas
            .Include(s => s.Fields)
            .SingleOrDefaultAsync(x => x.Name.Equals(schemaName));
        if (schema is null)
        {
            throw new Exception($"Cannot find schema with name {schemaName}");
        }

        return schema;
    }
    
    private static string GetFieldsString(Schema schema)
    {
        var fields = schema.Fields.Select(f => f.Name);
        var fieldsString = string.Join(",", fields);
        return fieldsString;
    }
}