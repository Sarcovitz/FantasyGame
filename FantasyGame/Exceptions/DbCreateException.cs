namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send InternalServerError (500) HTTP Status - caused by database CREATE operation.
/// </summary>
[Serializable]
public class DbCreateException : Exception
{
    /// <summary>
    ///     Constructor for <see cref="DbCreateException"/>.
    /// </summary>
    public DbCreateException() { }

    /// <summary>
    ///     Constructor for <see cref="DbCreateException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    public DbCreateException(string message) : base(message) { }

    /// <summary>
    ///     Constructor for <see cref="DbCreateException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    /// <param name="inner">Inner <see cref="Exception"/>.</param>
    public DbCreateException(string message, Exception innerException) : base(message, innerException) { }
}
