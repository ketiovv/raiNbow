namespace RaiNbow.Cms;

public class Schema
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Field> Fields { get; set; } = [];
}