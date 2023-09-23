using bingo_api.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
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

    [HttpGet("{id:int}")]
    public IActionResult GetUserQuickplay(int id)
    {
        var userQuickPlayDto = new UserQuickplayDto
        {
            UserId = 1,
            Username = "James",
            UserLevel = 2,
            UserNextLvlRequiredPoints = 3000
        };

        var quickPlayDto = new QuickPlayDto
        {
            Id = 1,
            Name = "Balloon",
            points = 200,
            ScannableObjectId = 2
        };
        
        userQuickPlayDto.QuickPlayDtos.Add(quickPlayDto);
        
        var quickPlayDto2 = new QuickPlayDto
        {
            Id = 2,
            Name = "Car",
            points = 100,
            ScannableObjectId = 1
        };
        
        userQuickPlayDto.QuickPlayDtos.Add(quickPlayDto2);
        
        var quickPlayDto3 = new QuickPlayDto
        {
            Id = 3,
            Name = "Bird",
            points = 200,
            ScannableObjectId = 3
        };
        
        userQuickPlayDto.QuickPlayDtos.Add(quickPlayDto3);

        return Ok(userQuickPlayDto);
    }
    
}