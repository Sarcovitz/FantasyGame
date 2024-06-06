namespace FantasyGame.Configs;

public class LoggerConfig
{
    public bool UseConsoleLogger { get; set; } = false;
    public bool UseFileLogger { get; set; } = false;
    public bool UseSyslogLogger { get; set; } = false;
    public string FileLoggerPath { get; set; } = string.Empty;

}
