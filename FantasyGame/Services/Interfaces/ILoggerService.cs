using System.Runtime.CompilerServices;

namespace FantasyGame.Services.Interfaces;

/// <summary>
///     Interface for service responsible for logging informations.
/// </summary>
public interface ILoggerService
{
    /// <summary>
    ///     Methods that logs message with DEBUG log severity.
    /// </summary>
    /// <param name="message">Text of log message.</param>
    /// <param name="obj">Object to serialize</param>
    /// <param name="file">File where log was executed.</param>
    /// <param name="method">Method where log was executed.</param>
    /// <param name="line">Line where log was executed.</param>
    public void Debug(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0);

    /// <summary>
    ///     Methods that logs message with ERROR log severity.
    /// </summary>
    /// <param name="message">Text of log message.</param>
    /// <param name="obj">Object to serialize</param>
    /// <param name="file">File where log was executed.</param>
    /// <param name="method">Method where log was executed.</param>
    /// <param name="line">Line where log was executed.</param>
    public void Error(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0);

    /// <summary>
    ///     Methods that logs message with FATAL log severity.
    /// </summary>
    /// <param name="message">Text of log message.</param>
    /// <param name="obj">Object to serialize</param>
    /// <param name="file">File where log was executed.</param>
    /// <param name="method">Method where log was executed.</param>
    /// <param name="line">Line where log was executed.</param>
    public void Fatal(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0);

    /// <summary>
    ///     Methods that logs message with INFO log severity.
    /// </summary>
    /// <param name="message">Text of log message.</param>
    /// <param name="obj">Object to serialize</param>
    /// <param name="file">File where log was executed.</param>
    /// <param name="method">Method where log was executed.</param>
    /// <param name="line">Line where log was executed.</param>
    public void Info(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0);

    /// <summary>
    ///     Methods that logs message with WARN log severity.
    /// </summary>
    /// <param name="message">Text of log message.</param>
    /// <param name="obj">Object to serialize</param>
    /// <param name="file">File where log was executed.</param>
    /// <param name="method">Method where log was executed.</param>
    /// <param name="line">Line where log was executed.</param>
    public void Warn(string message, object? obj = null, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0);
}
