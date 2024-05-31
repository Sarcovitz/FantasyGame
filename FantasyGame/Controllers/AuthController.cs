using FantasyGame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    public IActionResult Index()
    {
        return View();
    }
}
