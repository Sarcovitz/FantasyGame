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
    public int SmtpPort { get; set; } = 0;

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

    /// <summary>
    ///     Gets or sets AddressFrom.
    /// </summary>
    public string EmailAddressFrom {  get; set; } = string.Empty;
}
