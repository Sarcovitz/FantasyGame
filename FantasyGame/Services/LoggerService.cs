using FantasyGame.Configs;
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

    public void Info(string message, [CallerFilePath]string file = "", [CallerMemberName]string memberName = "", [CallerLineNumber]int lineNumber = 0)
    {
        Console.Write($"{message}, {file}, {memberName}, {lineNumber}");
        Console.WriteLine(_fileLoggerConfig.FileLoggerPath);
    }
}