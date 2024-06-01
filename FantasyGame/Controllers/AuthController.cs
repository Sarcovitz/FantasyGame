﻿using FantasyGame.Extensions;
using FantasyGame.Models.Requests;
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
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    ///     Endpoint responsible for new user registration.
    /// </summary>
    ///     <param name="body"> Input data for new user registration</param>
    /// <returns></returns>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequest? body)
    {
        if (body is null)
            return BadRequest("Model cannot be null.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrors());

        RegisterUserDTO result = await _authService.RegisterAsync(body);

        return CreatedAtRoute("/user/me", result);
    }
}
