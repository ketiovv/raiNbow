namespace RaiNbow.Cms;

public interface IGenericSchemaRepository
{
    /// <summary>
    /// This method gets entries of given schema by name and returns serialized data.
    /// </summary>
    /// <returns>JSON array of the results</returns>
    Task<string> GetAllAsJsonAsync(string schemaName);
}
