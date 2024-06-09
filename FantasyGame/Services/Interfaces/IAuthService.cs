using FantasyGame.Models.Requests;
using FantasyGame.Models.Responses;

namespace FantasyGame.Services.Interfaces;

public interface IAuthService
{
    public Task<RegisterUserResponse?> RegisterNewUserAsync(RegisterUserRequest registerForm);
}
