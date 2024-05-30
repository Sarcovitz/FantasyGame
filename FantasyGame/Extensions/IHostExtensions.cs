using FantasyGame.DB;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Extensions;

public static class IHostExtensions
{
    public static bool InitializeDatabase<TContext>(this IHost host) where TContext : DbContext
    {
        try
        {
            using IServiceScope scope = host.Services.CreateScope();

            TContext? context = scope.ServiceProvider.GetRequiredService<TContext>();
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
