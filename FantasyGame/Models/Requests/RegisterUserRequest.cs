using System.ComponentModel.DataAnnotations;

namespace FantasyGame.Models.Requests;

/// <summary>
/// Represents input data necessary to register new user
/// </summary>
public class RegisterUserRequest
{
    /// <summary>
    /// Gets or sets Username value
    /// </summary>
    [Required]
    [MaxLength(16)]
    [MinLength(3)]
    [RegularExpression(@"^[a-zA-Z0-9]+$")]
    public string? Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Email value
    /// </summary>
    [Required]
    [MaxLength(320)] // what internet says
    [MinLength(6)] // e.g. x@x.us
    [EmailAddress]
    public string? Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Password value
    /// </summary>
    [Required]
    [MinLength(6)]
    public string? Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Password2 value
    /// </summary>
    [Required]
    [MinLength(6)]
    public string? Password2 { get; set;} = string.Empty;
}
