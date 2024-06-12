using FantasyGame.Enums;
using System.ComponentModel.DataAnnotations;

namespace FantasyGame.Models.Entities;

/// <summary>
///     Entity class representing a single record in Logs table.
/// </summary>
public class LogEntry
{
    /// <summary>
    ///     Gets or sets Id.
    /// </summary>
    [Required]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    ///     Gets or sets Date.
    /// </summary>
    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Gets or sets Severity.
    /// </summary>
    [Required]
    public LogSeverity Severity { get; set; } = LogSeverity.NONE;

    /// <summary>
    ///     Gets or sets File.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string File { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets Method.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Method { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets Line.
    /// </summary>
    [Required]
    public int Line { get; set; } = 0;

    /// <summary>
    ///     Gets or sets Message.
    /// </summary>
    [Required]
    public string Message { get; set; }  = string.Empty;
}
