using FantasyGame.Models.Entities;

namespace FantasyGame.Services.Interfaces;

public interface IEmailService
{
    public Task SendAccountConfirmationEmailAsync(User user);
}
