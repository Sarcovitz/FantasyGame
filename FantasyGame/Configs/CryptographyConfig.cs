﻿namespace FantasyGame.Configs;

/// <summary>
///     Represents data necessary to configure JWT Authentication
/// </summary>
public class CryptographyConfig
{
    /// <summary>
    ///     Gets or sets AesKey
    /// </summary>
    public string AesKey { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets AesIV
    /// </summary>
    public string AesIV { get; set; } = string.Empty;
}
