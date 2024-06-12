using FantasyGame.Enums;

namespace FantasyGame.Configs;

/// <summary>
///     Represents data necessary to perform general configuration of logging service.
/// </summary>
public class LoggerConfig
{
    /// <summary>
    ///     Gets or sets UseConsoleLogger.
    /// </summary>
    public LogSeverity MinimalLogLevel { get; set; } = LogSeverity.DEBUG;

    /// <summary>
    ///     Gets or sets UseConsoleLogger.
    /// </summary>
    public bool UseConsoleLogger { get; set; } = false;

    /// <summary>
    ///     Gets or sets UseFileLogger.
    /// </summary>
    public bool UseFileLogger { get; set; } = false;

    /// <summary>
    ///     Gets or sets FileLoggerConfig.
    /// </summary>
    public FileLoggerConfig? FileLoggerConfig { get; set; } = null;

    /// <summary>
    ///     Gets or sets UseDbLogger.
    /// </summary>
    public bool UseDbLogger { get; set; } = false;
}

/// <summary>
///     Represents data necessary to configure logging to file.
/// </summary>
public class FileLoggerConfig
{
    /// <summary>
    ///     Gets or sets SyslogLoggerConfig.
    /// </summary>
    public string FileLoggerPath { get; set; } = string.Empty;
}