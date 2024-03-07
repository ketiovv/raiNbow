namespace RaiNbow.Cms.CreateSchema;

internal record CreateSchemaRequest
{
    public string? Name { get; set; }
    public IEnumerable<FieldOnCreateSchemaRequest> Fields { get; set; } = [];
}

internal record FieldOnCreateSchemaRequest(string Name, int FieldTypeId);