using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyGame.Models.Entities;

public class User
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public ulong Id { get; set; }
    [Required]
    [MaxLength(16)]
    [MinLength(3)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    [MaxLength(320)]
    [MinLength(6)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MaxLength(64)]
    public string PasswordHash { get; set; } = string.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public bool IsEmailConfirmed { get; set; } = false;
}
