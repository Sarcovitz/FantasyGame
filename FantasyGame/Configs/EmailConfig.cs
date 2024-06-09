namespace FantasyGame.Configs;

/// <summary>
///     Represents data necessary to configure SMTP client.
/// </summary>
public class EmailConfig
{
    /// <summary>
    ///     Gets or sets SmtpServer.
    /// </summary>
    public string SmtpServer { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets SmtpPort.
    /// </summary>-
    public string SmtpPort { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets SmtpUsername.
    /// </summary>
    public string SmtpUsername { get; set;} = string.Empty;

    /// <summary>
    ///     Gets or sets SmtpPassword.
    /// </summary>
    public string SmtpPassword { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets SmtpEnableSSL.
    /// </summary>
    public bool SmtpEnableSSL { get; set; } = false;
}
