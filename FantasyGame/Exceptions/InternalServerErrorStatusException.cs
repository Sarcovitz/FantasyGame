namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send InternalServerError (500) HTTP Status.
/// </summary>
[Serializable]
public class InternalServerErrorStatusException : Exception
{
    public InternalServerErrorStatusException() { }
    public InternalServerErrorStatusException(string message) : base(message) { }
    public InternalServerErrorStatusException(string message, Exception inner) : base(message, inner) { }
}