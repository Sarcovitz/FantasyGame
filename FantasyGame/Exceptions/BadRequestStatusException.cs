namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send BadRequest (400) HTTP Status.
/// </summary>
[Serializable]
public class BadRequestStatusException : Exception
{
    public BadRequestStatusException() { }
    public BadRequestStatusException(string message) : base(message) { }
    public BadRequestStatusException(string message, Exception inner) : base(message, inner) { }
}