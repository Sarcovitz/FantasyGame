using FantasyGame.Models.Entities;
using FantasyGame.Models.Requests;
using FantasyGame.Models.Responses;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services.Interfaces;
using System.Data;

namespace FantasyGame.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<RegisterUserResponse> RegisterNewUserAsync(RegisterUserRequest registerForm)
    {
        if (registerForm.Password != registerForm.Password2)
            throw new ArgumentException("Supplied paswords are not equal.");

        User? user = await _userRepository.GetByUsernameAsync(registerForm.Username!);
        if (user is not null)
            throw new DuplicateNameException("User with supplied username already exists.");

        user = await _userRepository.GetByEmailAsync(registerForm.Email!);
        if (user is not null)
            throw new DuplicateNameException("User with supplied e-mail already exists.");

        User newUser = new()
        {
            Username = registerForm.Username!,
            Email = registerForm.Email!,
            PasswordHash = _cryptographyService.Sha256Hash(registerForm.Password!),
        };

        newUser = await _userRepository.CreateAsync(newUser);
        bool emailSendingResult = _emailService.SendAccountConfirmationEmail(newUser);

        if (!emailSendingResult)
            throw new Exception($"Account has been created but confirmation link could not be sent, please contact support.");

        var result = new RegisterUserResponse()
        {
            Id = newUser.Id,
            Username = newUser.Username,
            Email = newUser.Email,
        };

        return result;
    }
}
