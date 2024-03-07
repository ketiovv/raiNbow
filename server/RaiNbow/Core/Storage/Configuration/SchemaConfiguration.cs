using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaiNbow.Cms;

namespace RaiNbow.Core.Storage.Configuration;

public class SchemaConfiguration : IEntityTypeConfiguration<Schema>
{
    public void Configure(EntityTypeBuilder<Schema> builder)
    {
        builder.ToTable($"{StorageConstants.CmsSchema}_schemas", schema: StorageConstants.CmsSchema);
    }
}