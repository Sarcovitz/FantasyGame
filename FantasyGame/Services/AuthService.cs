using FantasyGame.Exceptions;
using FantasyGame.Models.Entities;
using FantasyGame.Models.Requests;
using FantasyGame.Models.Responses;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services.Interfaces;

namespace FantasyGame.Services;

/// <summary>
///     Service responsible for user authentication related operations. Implementation of <see cref="IAuthService"/> interface.
/// </summary>
public class AuthService : IAuthService
{
    private readonly ICryptographyService _cryptographyService;
    private readonly IEmailService _emailService;

    private readonly IUserRepository _userRepository;

    private readonly ILoggerService _logger;

    /// <summary>
    ///     Constructor for <see cref="AuthService"/>.
    /// </summary>
    /// <param name="cryptographyService"> Injected <see cref="ICryptographyService"/> implementation.</param>
    /// <param name="emailService"> Injected <see cref="IEmailService"/> implementation.</param>
    /// 
    /// <param name="userRepository"> Injected <see cref="IUserRepository"/> implementation.</param>
    /// 
    /// <param name="logger"> Injected <see cref="ILoggerService"/> implementation.</param>
    public AuthService(
        ICryptographyService cryptographyService, 
        IEmailService emailService,

        IUserRepository userRepository,
        ILoggerService logger)
    {
        _cryptographyService = cryptographyService;
        _emailService = emailService;

        _userRepository = userRepository;
        _logger = logger;
    }

    #region IAuthService

    public async Task<RegisterUserResponse> RegisterNewUserAsync(RegisterUserRequest registerForm)
    {
        string password1 = string.Empty;
        string password2 = string.Empty;

        try
        {
            password1 = await _cryptographyService.AesDecryptAsync(registerForm.Password!);
            password2 = await _cryptographyService.AesDecryptAsync(registerForm.Password2!);
        }
        catch (Exception ex)
        {
            _logger.Error($"Could not decrypt supplied passwords' ciphers: p1 - {registerForm.Password!} p2 - {registerForm.Password2!}");
            throw new BadRequestStatusException("Could not decrypt supplied passwords' ciphers.");
        }

        if (password1 != password2)
        {
            _logger.Debug($"Supplied passwords are not identical: p1 - {password1} p2 - {password2}");
            throw new BadRequestStatusException("Supplied paswords are not equal.");
        }

        User? user = await _userRepository.GetByUsernameAsync(registerForm.Username!);
        if (user is not null)
        {
            _logger.Debug($"User with supplied username already exists. Username: {registerForm.Username!} User ID: {user.Id}");
            throw new ConflictStatusException("User with supplied username already exists.");
        }

        user = await _userRepository.GetByEmailAsync(registerForm.Email!);
        if (user is not null)
        {
            _logger.Debug($"User with supplied e-mail address already exists. E-mail address: {registerForm.Email!} User ID: {user.Id}");
            throw new ConflictStatusException("User with supplied e-mail address already exists.");
        }

        User newUser = new()
        {
            Username = registerForm.Username!,
            Email = registerForm.Email!,
            PasswordHash = await _cryptographyService.GetSha256HashAsync(password1),
        };

        newUser = await _userRepository.CreateAsync(newUser);

        try
        {
            await _emailService.SendAccountConfirmationEmailAsync(newUser);
        }
        catch (Exception) 
        {
            _logger.Error($"Error while sending account confirmation e-mail. E-mail address: {registerForm.Email!} User ID: {user.Id}");
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

    #endregion IAuthService
}
