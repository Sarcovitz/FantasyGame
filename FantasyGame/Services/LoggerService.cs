using FantasyGame.Configs;
using FantasyGame.Enums;
using FantasyGame.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace FantasyGame.Services;

public class LoggerService : ILoggerService, IDisposable
{
    private readonly LoggerConfig _config;

    private readonly FileLoggerConfig _fileLoggerConfig = new();
    private readonly SyslogLoggerConfig _syslogLoggerConfig = new();

    private readonly UdpClient _udpClient = new();

    public LoggerService(IOptions<LoggerConfig> config)
    {
        _config = config.Value;

        if (_config.UseFileLogger)
        {
            if (_config.FileLoggerConfig is null)
            {
                throw new Exception("Cannot configure FileLogger - config is null.");
            }

            _fileLoggerConfig = _config.FileLoggerConfig;
        }

        if (_config.UseSyslogLogger)
        {
            if (_config.SyslogLoggerConfig is null)
            {
                throw new Exception("Cannot configure SyslogLogger - config is null.");
            }

            _syslogLoggerConfig = _config.SyslogLoggerConfig;
        }
    }

    #region ILoggerService

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

    #endregion ILoggerService

    #region Non-interface
    
    private void LogMessage(LogSeverity logLevel, string message, string file, string method, int line)
    {
        string logMessageBase = $"{file} {method} {line} {message}";

        if (_config.UseConsoleLogger)
        {
            LogToConsole(logMessageBase);
        }

        if (_config.UseFileLogger)
        {
            LogToFile(logMessageBase);
        }

        if (_config.UseSyslogLogger)
        {
            LogToSyslog(logMessageBase);
        }
    }

    private void LogToConsole(string message)
    {
        try
        {
            string log = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:dd:ffff} {message}";

            Console.WriteLine(log);
        }
        catch { }
    }

    private void LogToFile(string message)
    {
        try
        {
            string log = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:dd:ffff} {message}";
            if (File.Exists(_fileLoggerConfig.FileLoggerPath))
            {
                File.AppendAllText(_fileLoggerConfig.FileLoggerPath, log);
            }
            else
            {
                File.Create(_fileLoggerConfig.FileLoggerPath);
            }
        }
        catch { }
    }

    private void LogToSyslog(string message)
    {
        try
        {
            string log = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:dd:ffff} {message}";

            byte[] data = Encoding.UTF8.GetBytes(log);
            _udpClient.Send(data, data.Length, _syslogLoggerConfig.ServerHostname, _syslogLoggerConfig.ServerPort);
        }
        catch { }
    }

    // TODO: LogToDb method

    #endregion Non-interface

    #region IDisposable

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _udpClient?.Dispose();
    }

    #endregion IDisposable
}