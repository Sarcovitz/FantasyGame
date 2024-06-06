namespace FantasyGame.Configs;

public class LoggerConfig
{
    public bool UseConsoleLogger { get; set; } = false;
    public bool UseFileLogger { get; set; } = false;
    public FileLoggerConfig? FileLoggerConfig { get; set; } = null;
    public bool UseSyslogLogger { get; set; } = false;
    public SyslogLoggerConfig? SyslogLoggerConfig { get; set; } = null;
}

public class FileLoggerConfig
{
    public string FileLoggerPath { get; set; } = string.Empty;
}

public class SyslogLoggerConfig
{
    public string ServerHostname { get; set; } = string.Empty;
    public int ServerPort { get; set; } = 0;
    public string SyslogIdentifier { get; set; } = string.Empty;
}