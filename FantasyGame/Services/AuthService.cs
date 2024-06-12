using FantasyGame.Exceptions;
using FantasyGame.Models.Entities;
using FantasyGame.Models.Requests;
using FantasyGame.Models.Responses;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services.Interfaces;
using System.Data;

namespace FantasyGame.Services;

public class AuthService : IAuthService
{
    private readonly ICryptographyService _cryptographyService;
    private readonly IEmailService _emailService;

    private readonly IUserRepository _userRepository;

    /// <summary>
    ///     Constructor for <see cref="AuthService"/>
    /// </summary>
    /// <param name="cryptographyService"> Injected <see cref="ICryptographyService"/> implementation.</param>
    /// <param name="emailService"> Injected <see cref="IEmailService"/> implementation.</param>
    /// 
    /// <param name="userRepository"> Injected <see cref="IUserRepository"/> implementation.</param>
    public AuthService(
        ICryptographyService cryptographyService, 
        IEmailService emailService,

        IUserRepository userRepository)
    {
        _cryptographyService = cryptographyService;
        _emailService = emailService;

        _userRepository = userRepository;
    }

    public async Task<RegisterUserResponse> RegisterNewUserAsync(RegisterUserRequest registerForm)
    {
        string password1 = await _cryptographyService.AesDecryptAsync(registerForm.Password!);
        string password2 = await _cryptographyService.AesDecryptAsync(registerForm.Password2!);

        if (password1 != password2)
            throw new BadRequestStatusException("Supplied paswords are not equal.");

        User? user = await _userRepository.GetByUsernameAsync(registerForm.Username!);
        if (user is not null)
            throw new ConflictStatusException("User with supplied username already exists.");

        user = await _userRepository.GetByEmailAsync(registerForm.Email!);
        if (user is not null)
            throw new ConflictStatusException("User with supplied e-mail already exists.");

        User newUser = new()
        {
            Username = registerForm.Username!,
            Email = registerForm.Email!,
            PasswordHash = await _cryptographyService.GetSHA256HashAsync(password1),
        };

        newUser = await _userRepository.CreateAsync(newUser);

        try
        {
            await _emailService.SendAccountConfirmationEmailAsync(newUser);
        }
        catch (Exception ex) 
        {
            //TODO logs
            throw new InternalServerErrorStatusException($"Error while sending account confirmation e-mail.");
        }

        var result = new RegisterUserResponse()
        {
            Id = newUser.Id,
            Username = newUser.Username,
            Email = newUser.Email,
        };

        return result;
    }
}
