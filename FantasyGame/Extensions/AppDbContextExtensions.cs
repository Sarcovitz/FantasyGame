using FantasyGame.DB;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Extensions;

public static class AppDbContextExtensions
{
    public static bool InitializeDatabase(this AppDbContext context)
    {
        try
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();

            return true;
        }
        catch
        {
            //TODO log
            return false;
        }
    }
}
