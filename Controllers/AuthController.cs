using bingo_api.Models.Services.Auth;
using bingo_api.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
public class AuthController : Controller
{
    private ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }
    
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try
        {
            return Ok(await _authService.Login(loginUserDto));
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> SignUp([FromBody] RegisterUserDto registerUserDto)
    {
        try
        {
            await _authService.Register(registerUserDto);
        }
        catch (BadHttpRequestException)
        {
            return BadRequest("Username already exists");
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }

        return Ok("User has been registered!");
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto refreshTokenDto)
    {
        var tokenDto = await _authService.Refresh(refreshTokenDto.RefreshToken);
        return Ok(tokenDto);
    }
    
}