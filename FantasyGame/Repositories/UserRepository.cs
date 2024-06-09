using FantasyGame.DB;
using FantasyGame.Exceptions;
using FantasyGame.Models.Entities;
using FantasyGame.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Repositories;

/// <summary>
///     Repository responsible for <see cref="User"/> entity.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    ///     Constructor for <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="context"> Injected <see cref="AppDbContext"/> implementation. </param>
    public UserRepository(AppDbContext context)
    {
        _context = context;
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
        }
        catch (Exception ex)
        {
            throw new DbCreateException("User creation failed.", ex);
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
