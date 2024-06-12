using FantasyGame.Configs;
using FantasyGame.Models.Entities;
using FantasyGame.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FantasyGame.Services;

/// <summary>
///     Service responsible for sending e-mail messages. Implementation of <see cref="IEmailService"/> interface.
/// </summary>
public class EmailService : IEmailService
{
    private readonly EmailConfig _emailConfig;

    private readonly SmtpClient _smtpClient;

    /// <summary>
    ///     Contructor for <see cref="EmailService"/>.
    /// </summary>
    /// <param name="emailConfig">Injected <see cref="EmailConfig"/> object.</param>
    public EmailService(IOptions<EmailConfig> emailConfig)
    {
        _emailConfig = emailConfig.Value;

        _smtpClient = new SmtpClient(_emailConfig.SmtpServer)
        {
            Port = _emailConfig.SmtpPort,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential()
            {
                UserName = _emailConfig.SmtpUsername,
                Password = _emailConfig.SmtpPassword
            },
            EnableSsl = true            
        };
    }

    #region IEmailService

    public async Task SendAccountConfirmationEmailAsync(User user)
    {
        string userDataRaw = $"{user.Username}:{user.Id}:{user.Email}";
        string userData = Convert.ToBase64String(Encoding.UTF8.GetBytes(userDataRaw));
        string userDataUrlEncoded = WebUtility.UrlEncode(userData);

        string confirmationUrl = @$"{"test"}/auth/confirm-account/{userDataUrlEncoded}"; // TODO DOMAIN FROM CONFIG
        string filePath = @"./EmailTemplates/AccountConfirmationEmail.html";

        if (!File.Exists(filePath))
        {
            //TODO LOG
            //TODO EXCEPTION
        }

        string messageContent = await File.ReadAllTextAsync(filePath);
        messageContent = messageContent.Replace("***USERNAME***", user.Username);
        messageContent = messageContent.Replace("***LINK***", confirmationUrl);

        MailAddress mailFrom = new(_emailConfig.EmailAddressFrom, "FANTASY GAME");
        MailAddress mailTo = new(user.Email, user.Username.ToUpper());
        MailMessage msg = new(mailFrom, mailTo)
        {
            SubjectEncoding = Encoding.UTF8,
            BodyEncoding = Encoding.UTF8,
            Subject = "E-mail address confirmation.",
            Body = messageContent,
            IsBodyHtml = true
        };

        await Task.Run(() => _smtpClient.Send(msg));
    }

    #endregion IEmailService
}
