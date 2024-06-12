using FantasyGame.DB;
using FantasyGame.Exceptions;
using FantasyGame.Models.Entities;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Repositories;

/// <summary>
///     Repository responsible for <see cref="User"/> entity.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    private readonly ILoggerService _logger;
    /// <summary>
    ///     Constructor for <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="context"> Injected <see cref="AppDbContext"/> implementation. </param>
    /// <param name="logger"> Injected <see cref="ILoggerService"/> implementation. </param>
    public UserRepository(AppDbContext context,
        ILoggerService logger)
    {
        _context = context;

        _logger = logger;
    }

    public async Task<User> CreateAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            int result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("User create operation failed with SaveChangesAsync result = 0");
            }

            _logger.Info("User successfully created.", user);
        }
        catch (Exception ex)
        {
            _logger.Error($"User creation failed. Inner message: {ex.Message}", user);
            throw new DbCreateException($"User creation failed.");
        }

        return user;
    }

    public async Task<bool> DeleteAsync(ulong id)
    {
        User? user = await GetByIdAsync(id) ??
            throw new KeyNotFoundException($"User with ID:{id} not found or is already deleted.");

        _context.Users.Remove(user);
        int result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<User?> GetByEmailAsync(string email)
       => await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));

    public async Task<User?> GetByIdAsync(ulong id)
        => await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

    public async Task<User?> GetByUsernameAsync(string username)
        => await _context.Users.FirstOrDefaultAsync(user => user.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));

    public async Task<bool> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        int result = await _context.SaveChangesAsync();

        return result > 0;
    }
}
