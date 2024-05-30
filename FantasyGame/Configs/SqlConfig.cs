namespace FantasyGame.Configs;

/// <summary>
/// Represents data necessary to configure connection to SQL database
/// </summary>
public class SqlConfig
{
    /// <summary>
    /// Gets or sets connection string to SQL database
    /// </summary>
    public string ConnectionString { get; } = string.Empty;
}