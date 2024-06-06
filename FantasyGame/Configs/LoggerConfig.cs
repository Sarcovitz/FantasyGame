namespace FantasyGame.Configs;

/// <summary>
///     Represents data necessary to perform general configuration of logging service.
/// </summary>
public class LoggerConfig
{
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
    ///     Gets or sets UseSyslogLogger.
    /// </summary>
    public bool UseSyslogLogger { get; set; } = false;

    /// <summary>
    ///     Gets or sets SyslogLoggerConfig.
    /// </summary>
    public SyslogLoggerConfig? SyslogLoggerConfig { get; set; } = null;
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

/// <summary>
///     Represents data necessary to configure logging to Syslog system.
/// </summary>
public class SyslogLoggerConfig
{
    /// <summary>
    ///     Gets or sets ServerHostname.
    /// </summary>
    public string ServerHostname { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets ServerPort.
    /// </summary>
    public int ServerPort { get; set; } = 0;

    /// <summary>
    ///     Gets or sets SyslogIdentifier.
    /// </summary>
    public string SyslogIdentifier { get; set; } = string.Empty;
}