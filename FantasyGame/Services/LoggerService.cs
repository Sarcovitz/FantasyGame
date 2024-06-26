﻿using FantasyGame.Configs;
using FantasyGame.DB;
using FantasyGame.Enums;
using FantasyGame.Models.Entities;
using FantasyGame.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace FantasyGame.Services;

/// <summary>
///     Service responsible for logging informations. Implementation of <see cref="ILoggerService"/> interface.
/// </summary>
public class LoggerService : ILoggerService
{
    private readonly AppDbContext _context;
    private readonly LoggerConfig _config;

    private readonly FileLoggerConfig _fileLoggerConfig = new();

    /// <summary>
    ///     Constructor for <see cref="LoggerService"/>.
    /// </summary>
    /// <param name="context">Injected <see cref="AppDbContext"/>.</param>
    /// <param name="config">Injected <see cref="LoggerConfig"/> object.</param>
    /// <exception cref="Exception"></exception>
    public LoggerService(AppDbContext context, IOptions<LoggerConfig> config)
    {
        _config = config.Value;
        _context = context; 

        if (_config.UseFileLogger)
        {
            if (_config.FileLoggerConfig is null)
            {
                throw new Exception("Cannot configure FileLogger - config is null.");
            }

            _fileLoggerConfig = _config.FileLoggerConfig;
        }
    }

    #region ILoggerService

    public void Debug(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.DEBUG, message, file, method, line, obj);
    public void Error(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.ERROR, message, file, method, line, obj);

    public void Fatal(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.FATAL, message, file, method, line, obj);

    public void Info(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.INFO, message, file, method, line, obj);

    public void Warn(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        => LogMessage(LogSeverity.WARN, message, file, method, line, obj);

    #endregion ILoggerService

    #region Non-interface

    /// <summary>
    ///     Method that is facade for logging to multiple targets.
    /// </summary>
    /// <param name="logLevel">Log severity of log message.</param>
    /// <param name="message">Text of log message.</param>
    /// <param name="obj">Object to serialize</param>
    /// <param name="file">File where log was executed.</param>
    /// <param name="method">Method where log was executed.</param>
    /// <param name="line">Line where log was executed.</param>
    /// <exception cref="ArgumentException"></exception>
    private void LogMessage(LogSeverity logLevel, string message, string file, string method, int line, object? obj = null)
    {
        if(logLevel < _config.MinimalLogLevel)
        {
            return;
        }

        file = Path.GetFileName(file);
        if (obj is not null)
        {
            string serializedObject = JsonConvert.SerializeObject(obj, Formatting.Indented);
            message += Environment.NewLine + "OBJECT:";
            message += Environment.NewLine + serializedObject;
        }
        string logMessageBase = $"{file} {method} {line} {message}";

        if (_config.UseConsoleLogger)
        {
            LogToConsole(logLevel, logMessageBase);
        }

        if (_config.UseFileLogger)
        {
            LogToFile(logLevel, logMessageBase);
        }
        
        if (_config.UseDbLogger)
        {
            LogToDatabase(logLevel, message, file, method, line);
        }
    }

    /// <summary>
    ///     Method that prints log message on console.
    /// </summary>
    /// <param name="logLevel">Log severity of log message.</param>
    /// <param name="message">Text of log message.</param>
    private static void LogToConsole(LogSeverity logLevel, string message)
    {
        try
        {
            string log = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:dd:ffff} [{logLevel}] {message}";

            Console.WriteLine(log);
        }
        catch { }
    }

    /// <summary>
    ///     Method that prints log message to database.
    /// </summary>
    /// <param name="logLevel">Log severity of log message.</param>
    /// <param name="message">Text of log message.</param>
    /// <param name="file">File where log was executed.</param>
    /// <param name="method">Method where log was executed.</param>
    /// <param name="line">Line where log was executed.</param>
    private void LogToDatabase(LogSeverity logLevel, string message, string file, string method, int line)
    {
        try
        {
            LogEntry log = new()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Severity = logLevel,
                File = file,
                Method = method,
                Line = line,
                Message = message,
            };

            int result = 0;
            int currentAttempt = 0;
            int maxAttempts = 5;
            do
            {
                currentAttempt++;
                _context.LogEntries.Add(log);
                result = _context.SaveChanges();
            }
            while (result < 1 && currentAttempt <= maxAttempts);
        }
        catch { }
    }

    /// <summary>
    ///     Method that prints log message to file.
    /// </summary>
    /// <param name="logLevel">Log severity of log message.</param>
    /// <param name="message">Text of log message.</param>
    private void LogToFile(LogSeverity logLevel, string message)
    {
        try
        {
            string log = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:dd:ffff} [{logLevel}] {message}{Environment.NewLine}";
            string path = _fileLoggerConfig.FileLoggerPath + $"\\logfile_{DateTime.UtcNow:yyyy-MM-dd}.log";
            if (File.Exists(path))
            {
                File.AppendAllText(path, log);
            }
            else
            {
                File.Create(path).Close();
                File.AppendAllText(path, log);
            }
        }
        catch { }
    }

    #endregion Non-interface
}