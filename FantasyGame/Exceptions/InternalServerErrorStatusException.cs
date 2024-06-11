namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send InternalServerError (500) HTTP Status.
/// </summary>
[Serializable]
public class InternalServerErrorStatusException : Exception
{
    /// <summary>
    ///     Constructor for <see cref="BadRequestStatusException"/>.
    /// </summary>
    public InternalServerErrorStatusException() { }

    /// <summary>
    ///     Constructor for <see cref="BadRequestStatusException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    public InternalServerErrorStatusException(string message) : base(message) { }

    /// <summary>
    ///     Constructor for <see cref="BadRequestStatusException"/>.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    /// <param name="inner">Inner <see cref="Exception"/>.</param>
    public InternalServerErrorStatusException(string message, Exception inner) : base(message, inner) { }
}