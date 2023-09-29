using bingo_api.Models.Entities;
using bingo_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelController : ControllerBase
{
    private readonly ILevelService _levelService;
    private readonly IRepository<Level> _levelRepo;
    private readonly ILogger<LevelController> _logger;
    
    public LevelController(ILevelService levelService, IRepository<Level> levelRepo, ILogger<LevelController> logger)
    {
        _levelService = levelService;
        _levelRepo = levelRepo;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetLevels()
    {
        _logger.LogInformation("Attempting to get all Levels");
        return Ok(await _levelRepo.GetAllAsync());
    }
}