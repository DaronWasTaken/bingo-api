using bingo_api.Models;
using bingo_api.Models.Services.Auth;
using bingo_api.Models.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
public class AuthController : Controller
{
    private ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, UserManager<User> userManager, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("oauth-login")]
    public async Task<IActionResult> LoginForm([FromForm] LoginUserDto loginUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(await _authService.Login(loginUserDto));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(await _authService.Login(loginUserDto));
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> SignUp([FromBody] RegisterUserDto registerUserDto)
    {
        var isRegistered = await _authService.Register(registerUserDto);

        if (!isRegistered)
        {
            return BadRequest("Registration failed");
        }

        return Ok("User has been registered!");
    }
    
}