using bingo_api.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuickplayController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetUserQuickplay(int id)
    {
        var userQuickPlayDto = new UserQuickplayDto
        {
            UserId = 1,
            Username = "James",
            UserLevel = 2,
            UserNextLvlRequiredPoints = 3000,
            QuickPlayDtos = new List<QuickPlayDto>()
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