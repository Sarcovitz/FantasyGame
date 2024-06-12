using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Extensions;

/// <summary>
///     Extension class for <see cref="IHost"/> type.
/// </summary>
public static class IHostExtensions
{
    /// <summary>
    ///     Initializing database by updating it with actual migrations.
    /// </summary>
    /// <typeparam name="TContext">Object of DbContext.</typeparam>
    /// <param name="host">Extended object of <see cref="IHost"/>.</param>
    /// <returns>A <see cref="bool"/> result indicating success or failure.</returns>
    public static bool InitializeDatabase<TContext>(this IHost host) where TContext : DbContext
    {
        try
        {
            using IServiceScope scope = host.Services.CreateScope();

            TContext? context = scope.ServiceProvider.GetRequiredService<TContext>();
            
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
