using bingo_api.Models.Entities.Services.Achievement;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AchievementController : ControllerBase
{
    private readonly IAchievementService _achievementService;

    public AchievementController(IAchievementService achievementService)
    {
        _achievementService = achievementService;
    }

    [HttpPost("/subtask/{subtaskId}")]
    public async Task<IActionResult> AwardSubtask(string subtaskId)
    {
        await _achievementService.AwardSubtaskScan(subtaskId);
        return NoContent();
    }
}