using System.ComponentModel.DataAnnotations;
using bingo_api.Models.Entities;
using bingo_api.Models.EntityProviders;
using Microsoft.AspNetCore.Mvc;

namespace bingo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetUser(int id)
    {
        return Ok(UserProvider.User);
    }

    //TODO: Include all parameters inside request body
    [HttpPost("{id:int}/quickplay/award")]
    public IActionResult AwardQuickplayObject(int id, [Required] int quickplayObjectId)
    {
        QuickplayObject quickplayObject = QuickplayObjectListProvider.QuickplayObjects.Find(qp => qp.QuickplayObjectId == quickplayObjectId)!;
        UserProvider.User.Points += quickplayObject.Points;
        QuickplayObjectListProvider.QuickplayObjects.Remove(quickplayObject);
        QuickplayObjectListProvider.QuickplayObjects.Add(new QuickplayObject
        {
            QuickplayObjectId = 16,
            Name = "Beer",
            Points = 200,
            ScanDate = DateTime.Today,
            ScanTypeId = 7
        });
        return NoContent();
    }
}