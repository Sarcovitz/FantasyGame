namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send Conflict (409) HTTP Status.
/// </summary>
[Serializable]
public class ConflictStatusException : Exception
{
    /// <summary>
    ///     Constructor for <see cref="ConflictStatusException"/>.
    /// </summary>
    public ConflictStatusException() { }

    /// <summary>
    ///     Constructor for <see cref="ConflictStatusException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    public ConflictStatusException(string message) : base(message) { }

    /// <summary>
    ///     Constructor for <see cref="ConflictStatusException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    /// <param name="inner">Inner <see cref="Exception"/>.</param>
    public ConflictStatusException(string message, Exception inner) : base(message, inner) { }
}