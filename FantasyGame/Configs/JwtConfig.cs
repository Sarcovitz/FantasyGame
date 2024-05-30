﻿namespace FantasyGame.Configs;

/// <summary>
/// Represents data necessary to configure JWT Authentication
/// </summary>
public class JwtConfig
{
    public string Key { get; set; } = string.Empty; // Must be 32 characters long.
}
