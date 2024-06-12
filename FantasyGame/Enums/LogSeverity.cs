namespace FantasyGame.Enums;

/// <summary>
///     Defines logging severity levels.
/// </summary>
public enum LogSeverity
{
    /// <summary>
    ///     Not used for writing log messages. Indicates undefined value.
    /// </summary>
    NONE = 0,

    /// <summary>
    ///     Logs that are used for interactive investigation during development.  These logs should primarily contain
    ///     information useful for debugging and have no long-term value.
    /// </summary>
    DEBUG = 1,

    /// <summary>
    ///     Logs that track the general flow of the application. These logs should have long-term value.
    /// </summary>
    INFO = 2,

    /// <summary>
    ///     Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the
    ///     application execution to stop.
    /// </summary>
    WARN = 3,

    /// <summary>
    ///     Logs that highlight when the current flow of execution is stopped due to a failure. These should indicate a
    ///     failure in the current activity, not an application-wide failure.
    /// </summary>
    ERROR = 4,

    /// <summary>
    ///     Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires
    ///     immediate attention.
    /// </summary>
    FATAL = 5,    
}
