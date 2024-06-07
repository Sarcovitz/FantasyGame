namespace FantasyGame.Models.Responses;

/// <summary>
///     Represents response for /auth/register endpoint.
/// </summary>
public class RegisterUserResponse
{
    /// <summary>
    ///     Gets or sets Id.
    /// </summary>
    public ulong Id { get; set; } = 0;

    /// <summary>
    ///     Gets or sets Username.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets Email.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
