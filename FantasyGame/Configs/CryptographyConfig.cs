namespace FantasyGame.Configs;

/// <summary>
///     Represents data necessary to configure cryptography parameters.
/// </summary>
public class CryptographyConfig
{
    /// <summary>
    ///     Gets or sets AesKey.
    /// </summary>
    public string AesKey { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets AesIV.
    /// </summary>
    public string AesIV { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets HashSalt.
    /// </summary>
    public string HashSalt { get; set; } = string.Empty;
}
