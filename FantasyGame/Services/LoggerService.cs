using FantasyGame.Configs;
using FantasyGame.Enums;
using FantasyGame.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace FantasyGame.Services;

public class LoggerService : ILoggerService
{
    private readonly LoggerConfig _config;

    private readonly FileLoggerConfig _fileLoggerConfig = new();
    private readonly SyslogLoggerConfig _syslogLoggerConfig = new();

    public LoggerService(IOptions<LoggerConfig> config)
    {
        _config = config.Value;

        if(_config.UseFileLogger)
        {
            if (_config.FileLoggerConfig is null)
            {
                throw new Exception("Cannot configure FileLogger - config is null.");
            }

            _fileLoggerConfig = _config.FileLoggerConfig;
        }

        if(_config.UseSyslogLogger)
        {
            if (_config.SyslogLoggerConfig is null)
            {
                throw new Exception("Cannot configure SyslogLogger - config is null.");
            }

            _syslogLoggerConfig = _config.SyslogLoggerConfig;
        }
    }

    public void Debug(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.DEBUG, message, file, method, line);

    public void Error(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.ERROR, message, file, method, line);

    public void Fatal(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.FATAL, message, file, method, line);

    public void Info(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.INFO, message, file, method, line);

    public void Trace(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.TRACE, message, file, method, line);

    public void Warn(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.WARN, message, file, method, line);

    //
    //  OUT OF INTERFACE
    //

    private void LogMessage(LogSeverity logLevel, string message, string file, string method, int line)
    {

    }
}