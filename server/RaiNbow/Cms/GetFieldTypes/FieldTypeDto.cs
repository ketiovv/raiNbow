namespace RaiNbow.Cms.GetFieldTypes;

internal record FieldTypeDto
{
    public int Id { get; init; }
    public required string FieldName { get; init; }
    public required string TypeName { get; init; }

    internal static FieldTypeDto FromFieldType(FieldType ft)
        => new()
        {
            Id = ft.Id,
            FieldName = ft.FieldName,
            TypeName = ft.TypeName,
        };
}