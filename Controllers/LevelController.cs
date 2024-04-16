using bingo_api.Models;
using bingo_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelController : ControllerBase
{
    private readonly ILevelService _levelService;
    private readonly ILogger<LevelController> _logger;
    
    public LevelController(ILevelService levelService, ILogger<LevelController> logger)
    {
        _levelService = levelService;
        _logger = logger;
    }
}