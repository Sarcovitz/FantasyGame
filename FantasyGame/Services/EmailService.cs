using FantasyGame.Configs;
using FantasyGame.Models.Entities;
using FantasyGame.Services.Interfaces;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Principal;

namespace FantasyGame.Services;

public class EmailService : IEmailService
{
    private readonly EmailConfig _emailConfig;

    private readonly SmtpClient _smtpClient;

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

    public bool SendAccountConfirmationEmail(User user)
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
            return false;
        }

        string messageContent = File.ReadAllText(filePath);
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

        try
        {
            _smtpClient.Send(msg);
        }
        catch
        {
            //TODO add logs
            return false;
        }

        return true;
    }
}
