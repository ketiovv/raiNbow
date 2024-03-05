namespace RaiNbow.Cms;

public class Field
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    // type

    public Guid SchemaId { get; set; }
    public required Schema Schema { get; set; }
}