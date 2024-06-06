using FantasyGame.Enums;

namespace FantasyGame.Models.Entities;

public class LogEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public LogSeverity Severity { get; set; } = LogSeverity.NONE;
    public string Message { get; set; }  = string.Empty;
}
