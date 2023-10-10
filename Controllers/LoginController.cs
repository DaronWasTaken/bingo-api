using bingo_api.Models;
using bingo_api.Models.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private ILogger<LoginController> _logger;
    private readonly UserManager<User> _userManager;

    public LoginController(ILogger<LoginController> logger, UserManager<User> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    [HttpPost]
    public IActionResult Login(UserCredentialsDto userCredentials)
    {
        return Ok("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");
    }
    
}