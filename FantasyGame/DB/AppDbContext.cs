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
}
