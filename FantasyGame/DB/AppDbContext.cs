using FantasyGame.Configs;
using FantasyGame.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace FantasyGame.DB;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    private readonly SqlConfig _sqlConfig;

    public AppDbContext(IOptions<SqlConfig> sqlConfig)
    {
        _sqlConfig = sqlConfig.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_sqlConfig.ConnectionString, ServerVersion.AutoDetect(_sqlConfig.ConnectionString));        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<User> user = modelBuilder.Entity<User>();
        user.ToTable("Users");

        base.OnModelCreating(modelBuilder);
    }
}
