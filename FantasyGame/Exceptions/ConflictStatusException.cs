namespace FantasyGame.Exceptions;

/// <summary>
///     Exception thrown to send Conflict (409) HTTP Status.
/// </summary>
[Serializable]
public class ConflictStatusException : Exception
{
	public ConflictStatusException() { }
	public ConflictStatusException(string message) : base(message) { }
	public ConflictStatusException(string message, Exception inner) : base(message, inner) { }
}