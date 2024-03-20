namespace RaiNbow.Cms;

public class Field
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public int FieldTypeId { get; set; }
    public FieldType? FieldType { get; set; }

    public Guid SchemaId { get; set; }
    public Schema? Schema { get; set; }
}