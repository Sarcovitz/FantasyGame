using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyGame.Models.Entities;

/// <summary>
///     Entity class representing a single record in Users table.
/// </summary>
public class User
{
    /// <summary>
    ///     Gets or sets Id.
    /// </summary>
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public ulong Id { get; set; } = 0;

    /// <summary>
    ///     Gets or sets Username.
    /// </summary>
    [Required]
    [MaxLength(16)]
    [MinLength(3)]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets Email.
    /// </summary>
    [Required]
    [EmailAddress]
    [MaxLength(320)]
    [MinLength(6)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets PasswordHash.
    /// </summary>
    [Required]
    [MaxLength(64)]
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets CreatedAt.
    /// </summary>
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    ///     Gets or sets IsEmailConfirmed.
    /// </summary>
    [Required]
    public bool IsEmailConfirmed { get; set; } = false;
}
