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
    private readonly UserManager<User> _userManager;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, UserManager<User> userManager, IAuthService authService)
    {
        _logger = logger;
        _userManager = userManager;
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
        var user = new User
        {
            UserName = registerUserDto.Username,
            Email = registerUserDto.Email,
            LevelNumber = 1,
            Points = 0
        };

        var result = await _userManager.CreateAsync(user, registerUserDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok("User created successfully!");
    }
    
}