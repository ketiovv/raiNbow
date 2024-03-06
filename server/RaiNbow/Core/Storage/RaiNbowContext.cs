using Microsoft.EntityFrameworkCore;
using RaiNbow.Cms;

namespace RaiNbow.Core.Storage;

public class RaiNbowContext : DbContext
{
    public DbSet<Schema> Schemas { get; set; }
    public DbSet<Field> Fields { get; set; }
    public RaiNbowContext(DbContextOptions<RaiNbowContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(StorageConstants.DataSchema);
    }
}