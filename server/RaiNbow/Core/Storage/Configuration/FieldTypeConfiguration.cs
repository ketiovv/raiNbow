using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaiNbow.Cms;

namespace RaiNbow.Core.Storage.Configuration;

public class FieldTypeConfiguration: IEntityTypeConfiguration<FieldType>
{
    public void Configure(EntityTypeBuilder<FieldType> builder)
    {
        builder.ToTable($"{StorageConstants.CmsSchema}_FieldType", schema: StorageConstants.CmsSchema);
    }
}