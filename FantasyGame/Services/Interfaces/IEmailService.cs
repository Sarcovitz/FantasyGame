using FantasyGame.Models.Entities;

namespace FantasyGame.Services.Interfaces;

public interface IEmailService
{
    public bool SendAccountConfirmationEmail(User user);
}
