namespace RaiNbow.Cms.GetAllSchemas;

internal class SchemaDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public IEnumerable<FieldDto> Fields { get; set; } = [];

    internal static SchemaDto FromSchema(Schema s)
        => new()
        {
            Id = s.Id,
            Name = s.Name,
            Fields = s.Fields.Select(FieldDto.FromField)
        };
}