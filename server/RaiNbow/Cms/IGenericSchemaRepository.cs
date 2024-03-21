namespace RaiNbow.Cms;

public interface IGenericSchemaRepository
{
    /// <summary>
    /// This method gets entries of given schema by name and returns serialized data.
    /// </summary>
    /// <returns>JSON array of the results</returns>
    Task<string> GetAllAsJsonAsync(string schemaName);
    Task<string> GetByIdAsJsonAsync(string schemaName, Guid recordId);
    Task AddAsync(string schemaName, string json);
    Task UpdateAsync(string schemaName, Guid recordId, string json);
    Task DeleteAsync(string schemaName, Guid recordId);
}
