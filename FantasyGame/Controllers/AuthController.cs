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

    /// <summary>
    ///     Constructor for <see cref="AuthController"/>
    /// </summary>
    /// <param name="authService"> Injected <see cref="IAuthService"/> implementation </param>
    public AuthController(IAuthService authService) : base()
    {
        _authService = authService;
    }

    /// <summary>
    ///     Endpoint responsible for new user registration.
    /// </summary>
    ///     <param name="body"> Input data for new user registration</param>
    /// <returns>A task with <see cref="IActionResult"/> containing <see cref="RegisterUserResponse"/></returns>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterNewUserAsync([FromBody] RegisterUserRequest? body)
    {
        if (body is null)
            return BadRequest("Model cannot be null.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrors());

        RegisterUserResponse result = await _authService.RegisterNewUserAsync(body);

        return Ok(result);
    }
}
