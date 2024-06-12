using FantasyGame.Models.Requests;
using FantasyGame.Models.Responses;

namespace FantasyGame.Services.Interfaces;

/// <summary>
///     Interface for service responsible for user authentication related operations.
/// </summary>
public interface IAuthService
{
    /// <summary>
    ///     Register new user account.
    /// </summary>
    /// <param name="registerForm"> <see cref="RegisterUserRequest"/> object with input data to register new user.</param>
    /// <returns>A <see cref="Task"/> with <see cref="RegisterUserResponse"/>.</returns>
    /// <exception cref="Multiple exceptions"></exception>
    public Task<RegisterUserResponse> RegisterNewUserAsync(RegisterUserRequest registerForm);
}
