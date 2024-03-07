using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RaiNbow.Core.Storage.Configuration;

public class FieldConfiguration : IEntityTypeConfiguration<FieldConfiguration>
{
    public void Configure(EntityTypeBuilder<FieldConfiguration> builder)
    {
        builder.ToTable($"{StorageConstants.CmsSchema}_fields", schema: StorageConstants.CmsSchema);
    }
}