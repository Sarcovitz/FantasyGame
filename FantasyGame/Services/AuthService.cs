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
    private readonly ICryptographyService _cryptographyService;

    public AuthService(IUserRepository userRepository, ICryptographyService cryptographyService)
    {
        _userRepository = userRepository;
        _cryptographyService = cryptographyService;
    }

    public async Task<RegisterUserResponse> RegisterNewUserAsync(RegisterUserRequest registerForm)
    {
        string password1 = _cryptographyService.AesDecrypt(registerForm.Password!);
        string password2 = _cryptographyService.AesDecrypt(registerForm.Password2!);

        if (password1 != password2)
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
            PasswordHash = _cryptographyService.GetSHA256Hash(password1),
        };

        newUser = await _userRepository.CreateAsync(newUser);
       // bool emailSendingResult = _emailService.SendAccountConfirmationEmail(newUser);

        //if (!emailSendingResult)
            //throw new Exception($"Account has been created but confirmation link could not be sent, please contact support.");

        var result = new RegisterUserResponse()
        {
            Id = newUser.Id,
            Username = newUser.Username,
            Email = newUser.Email,
        };

        return result;
    }
}
