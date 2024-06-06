using FantasyGame.Enums;
using System.ComponentModel.DataAnnotations;

namespace FantasyGame.Models.Entities;

public class LogEntry
{
    [Required]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;
    [Required]
    public LogSeverity Severity { get; set; } = LogSeverity.NONE;
    [Required]
    public string File { get; set; } = string.Empty;
    [Required]
    public string Method { get; set; } = string.Empty;
    [Required]
    public int Line { get; set; } = 0;
    [Required]
    public string Message { get; set; }  = string.Empty;
}
