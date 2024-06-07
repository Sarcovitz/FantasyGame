using FantasyGame.Models.Entities;

namespace FantasyGame.Repositories.Interfaces;

public interface IUserRepository
{
    /// <summary>
    ///     Creates new <see cref="User"/> entity.
    /// </summary>
    /// <param name="user"> <see cref="User"/> entity to create.</param>
    /// <returns>A task that represents created <see cref="User"/> entity.</returns>
    public Task<User> CreateAsync(User user);

    /// <summary>
    ///     Deletes <see cref="User"/> entity with supplied <see cref="User.Id"/>.
    /// </summary>
    /// <param name="id"><see cref="User.Id"/> of entity to delete.</param>
    /// <returns>A task with <see cref="bool"/> value representing if operation ended with a success.</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public Task<bool> DeleteAsync(ulong id);

    /// <summary>
    ///     Gets <see cref="User"/> entity by supplied <see cref="User.Email"/>.
    /// </summary>
    /// <param name="email"><see cref="User.Email"/> of entity to get.</param>
    /// <returns>A task with nullable <see cref="User"/> entity.</returns>
    public Task<User?> GetByEmailAsync(string email);

    /// <summary>
    ///     Gets <see cref="User"/> entity by supplied <see cref="User.Id"/>.
    /// </summary>
    /// <param name="id"><see cref="User.Id"/> of entity to get.</param>
    /// <returns>A task with nullable <see cref="User"/> entity.</returns>
    public Task<User?> GetByIdAsync(ulong id);

    /// <summary>
    ///     Gets <see cref="User"/> entity by supplied <see cref="User.Username"/>.
    /// </summary>
    /// <param name="username"><see cref="User.Username"/> of entity to get.</param>
    /// <returns>A task with nullable <see cref="User"/> entity.</returns>
    public Task<User?> GetByUsernameAsync(string username);

    /// <summary>
    ///     Updates <see cref="User"/> entity with supplied one.
    /// </summary>
    /// <param name="user">Entity to update.</param>
    /// <returns>a Task with <see cref="bool"/> value representing if operation ended with a success.</returns>
    public Task<bool> UpdateAsync(User user);
}
