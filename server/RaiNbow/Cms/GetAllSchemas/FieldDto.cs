namespace RaiNbow.Cms.GetAllSchemas;

internal class FieldDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string FieldType { get; set; }


    internal static FieldDto FromField(Field f)
        => new()
        {
            Id = f.Id,
            Name = f.Name,
            FieldType = f.FieldType?.FieldName ??
                        throw new Exception(
                            $"FieldType must be specified on the field, but it is not on the field with ID: {f.Id}.")
        };
}