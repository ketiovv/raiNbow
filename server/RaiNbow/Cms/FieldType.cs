using System.Collections;

namespace RaiNbow.Cms;

public class FieldType
{
    public int Id { get; set; }
    public required string FieldName { get; set; }
    public required string TypeName { get; set; }

    public ICollection<Field> Fields { get; set; }
}