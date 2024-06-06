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
    public string Message { get; set; }  = string.Empty;
}
