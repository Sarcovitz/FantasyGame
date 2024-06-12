using FantasyGame.Extensions;
using FantasyGame.Models.Requests;
using FantasyGame.Models.Responses;
using FantasyGame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.Controllers;

/// <summary>
///     Controller responsible for process of user authentication.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    private readonly ILoggerService _logger;

    /// <summary>
    ///     Constructor for <see cref="AuthController"/>
    /// </summary>
    /// <param name="authService">Injected <see cref="IAuthService"/> implementation.</param>
    /// <param name="logger">Injected <see cref="ILoggerService"/> implementation.</param>
    public AuthController(
        IAuthService authService,
        ILoggerService logger) : base()
    {
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    ///     Endpoint responsible for new user registration.
    /// </summary>
    /// <param name="body"> Input data for new user registration.</param>
    /// <returns>A <see cref="Task"/> with <see cref="IActionResult"/> containing <see cref="RegisterUserResponse"/></returns>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterNewUserAsync([FromBody] RegisterUserRequest? body)
    {
        _logger.Debug("Endpoint [api/auth/register] called.");

        if (body is null)
        {
            _logger.Trace("Body is null");
            return BadRequest("Model cannot be null.");
        }

        if (!ModelState.IsValid)
        {
            _logger.Trace("ModelState is invalid");
            return BadRequest(ModelState.GetErrors());
        }

        RegisterUserResponse result = await _authService.RegisterNewUserAsync(body);
        _logger.Debug("");

        return Ok(result);
    }
}
