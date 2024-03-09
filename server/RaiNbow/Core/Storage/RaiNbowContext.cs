using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaiNbow.Cms;

namespace RaiNbow.Core.Storage;

public class RaiNbowContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Schema> Schemas { get; set; }
    public DbSet<Field> Fields { get; set; }
    public RaiNbowContext(DbContextOptions<RaiNbowContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema(StorageConstants.DataSchema);
    }
}