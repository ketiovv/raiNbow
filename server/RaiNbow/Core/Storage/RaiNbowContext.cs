using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RaiNbow.Cms;

namespace RaiNbow.Core.Storage;

public class RaiNbowContext : IdentityDbContext<IdentityUser>
{
    private readonly ILogger<RaiNbowContext> _logger;
    public DbSet<Schema> Schemas { get; set; }
    public DbSet<Field> Fields { get; set; }
    public RaiNbowContext(DbContextOptions<RaiNbowContext> options, ILogger<RaiNbowContext> logger) : base(options)
    {
        _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema(StorageConstants.DataSchema);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added)
            .Select(e => e.Entity)
            .ToList();

        foreach (var entity in addedEntities)
        {
            if (entity is Schema schema)
            {
                await OnCreateSchema(schema);
            }
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }

    // TODO:
    private Task OnCreateSchema(Schema schema)
    {
        _logger.LogInformation($"{nameof(Schema)} {schema.Name} is created. Creating table for this schema...");
        return Task.CompletedTask;
    }
}