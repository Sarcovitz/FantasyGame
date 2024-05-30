using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
