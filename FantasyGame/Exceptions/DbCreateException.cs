namespace FantasyGame.Exceptions;
/// <summary>
///     Exception thrown on database CREATE opeartion failrue.
/// </summary>
[Serializable]
public class DbCreateException : Exception
{
    public DbCreateException() { }

    public DbCreateException(string message) : base(message) { }

    public DbCreateException(string message, Exception innerException) : base(message, innerException) { }
}
