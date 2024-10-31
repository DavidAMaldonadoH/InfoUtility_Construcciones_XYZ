
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models = API.Models;
using API;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(ConstructionContext context) : ApiResponseService(context)
{
    [HttpGet("types")]
    public async Task<IActionResult> Search()
    {
        var projectType = await _context.ProjectTypes.ToListAsync();
        return CreateResult(200, projectType);
    }

    [HttpGet("states")]
    public async Task<IActionResult> States()
    {
        var projectState = await _context.ProjectStates.ToListAsync();
        return CreateResult(200, projectState);
    }

    [HttpGet("all")]
    public async Task<IActionResult> Projects()
    {
        var projects = await _context.Projects
        .Include(p => p.ProjectType)
        .Include(p => p.ProjectState)
        .ToListAsync();

        var apiProjects = projects.Select(p => p.ToApi()).ToList();
        return CreateResult(200, apiProjects);

    }

    [HttpGet("/get/{id}")]
    public async Task<IActionResult> Project(int id)
    {
        var project = await _context.Projects
        .Include(p => p.ProjectType)
        .Include(p => p.ProjectState)
        .FirstOrDefaultAsync(p => p.Id == id);

        if (project == null)
        {
            return CreateResult(404, "Project not found");
        }

        return CreateResult(200, project.ToApi());
    }

    [HttpPost("create")]
    public async Task<IActionResult> Project([FromBody] Models.Project project)
    {
        var newProject = new Project
        {
            Type = project.Type,
            Name = project.Name,
            Location = project.Location,
            Cost = project.Cost,
            State = project.State,
        };

        _context.Projects.Add(newProject);
        await _context.SaveChangesAsync();

        return CreateResult(200, newProject.ToApi());
    }
}