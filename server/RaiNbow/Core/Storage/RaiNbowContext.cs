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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
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

    private async Task OnCreateSchema(Schema schema)
    {
        _logger.LogInformation($"{nameof(Schema)} {schema.Name} is created. Creating table for this schema.");
        
        var createTableSql = $"CREATE TABLE \"{schema.Name}\" (Id SERIAL PRIMARY KEY)";

        try
        {
            await Database.ExecuteSqlRawAsync(createTableSql);
            _logger.LogInformation($"Table '{schema.Name}' has been created successfully.");

            await AddMigration($"CreateTable_{schema.Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to create table '{schema.Name}': {ex.Message}");
            throw;
        }
    }

    // TODO: Check how it can be done via code
    private async Task AddMigration(string migrationName)
    {
        _logger.LogInformation($"Creating migration: {migrationName}.");

        // var migrationProcess = Process.Start(
        //     "dotnet", 
        //     $@"ef migrations add {migrationName} 
        //                     --project RaiNbow 
        //                     --startup-project RaiNbow.API 
        //                     --output-dir Core/Storage/Migrations");
        //
        // await migrationProcess.WaitForExitAsync();
    }
}