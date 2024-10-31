using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EngineerController(
    ConstructionContext context
) : ApiResponseService(context)
{
    [HttpGet("all")]
    public async Task<IActionResult> Engineers()
    {
        var engineers = await _context.Engineers.ToListAsync();
        return CreateResult(200, engineers);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Engineer([FromBody] Models.Engineer engineer)
    {
        await _context.Engineers.AddAsync(new Engineer
        {
            FirstName = engineer.FirstName,
            LastName = engineer.LastName
        });
        await _context.SaveChangesAsync();
        return CreateResult(200, "Engineer created");
    }
}
