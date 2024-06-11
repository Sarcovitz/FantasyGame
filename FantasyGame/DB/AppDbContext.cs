using FantasyGame.Configs;
using FantasyGame.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace FantasyGame.DB;

/// <summary>
///     Main application database context.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    ///     Gets or sets LogEntries
    /// </summary>
    public DbSet<LogEntry> LogEntries { get; set; }

    /// <summary>
    ///     Gets or sets Users
    /// </summary>
    public DbSet<User> Users { get; set; }

    private readonly SqlConfig _sqlConfig;

    /// <summary>
    ///     Contructor for <see cref="AppDbContext"/>
    /// </summary>
    /// <param name="sqlConfig"><see cref="SqlConfig"/> injected object.</param>
    public AppDbContext(IOptions<SqlConfig> sqlConfig)
    {
        _sqlConfig = sqlConfig.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_sqlConfig.ConnectionString, ServerVersion.AutoDetect(_sqlConfig.ConnectionString), options =>
            {
                options.EnableStringComparisonTranslations();
            }
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<LogEntry> logEntry = modelBuilder.Entity<LogEntry>();
        logEntry.ToTable("Logs");
        logEntry.Property(x => x.Id)
            .HasDefaultValueSql("UUID()");

        EntityTypeBuilder<User> user = modelBuilder.Entity<User>();
        user.ToTable("Users");

        base.OnModelCreating(modelBuilder);
    }
}
