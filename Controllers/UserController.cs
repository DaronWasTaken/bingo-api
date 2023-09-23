using bingo_api.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[DisableCors]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var userDto = new UserDto
            ("James",
            2400,
            3,
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 2, 3 }
            );
        return Ok(userDto);
    }
}