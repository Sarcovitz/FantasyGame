namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send BadRequest (400) HTTP Status.
/// </summary>
[Serializable]
public class BadRequestStatusException : Exception
{
    /// <summary>
    ///     Constructor for <see cref="BadRequestStatusException"/>.
    /// </summary>
    public BadRequestStatusException() { }

    /// <summary>
    ///     Constructor for <see cref="BadRequestStatusException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    public BadRequestStatusException(string message) : base(message) { }

    /// <summary>
    ///     Constructor for <see cref="BadRequestStatusException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    /// <param name="inner">Inner <see cref="Exception"/>.</param>
    public BadRequestStatusException(string message, Exception inner) : base(message, inner) { }
}