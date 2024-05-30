using FantasyGame.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FantasyGame.DB;

public class AppDbContext : DbContext
{
    private readonly SqlConfig _sqlConfig;

    public AppDbContext(IOptions<SqlConfig> sqlConfig)
    {
        _sqlConfig = sqlConfig.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ServerVersion.AutoDetect(_sqlConfig.ConnectionString));        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("GAME");

        base.OnModelCreating(modelBuilder);
    }
}
