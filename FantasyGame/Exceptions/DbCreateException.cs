namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send InternalServerError (500) HTTP Status - caused by database CREATE operation.
/// </summary>
[Serializable]
public class DbCreateException : Exception
{
    public DbCreateException() { }

    public DbCreateException(string message) : base(message) { }

    public DbCreateException(string message, Exception innerException) : base(message, innerException) { }
}
