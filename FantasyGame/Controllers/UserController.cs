using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
