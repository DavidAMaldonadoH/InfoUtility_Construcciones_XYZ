
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
        .Include(p => p.Engineer)
        .Where(p => p.IsArchived == false)
        .ToListAsync();

        var apiProjects = projects.Select(p => p.ToApi()).ToList();
        return CreateResult(200, apiProjects);

    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Project(int id)
    {
        var project = await _context.Projects
        .Include(p => p.ProjectType)
        .Include(p => p.ProjectState)
        .Include(p => p.Engineer)
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
            EngineerId = project.EngineerId
        };

        _context.Projects.Add(newProject);
        await _context.SaveChangesAsync();

        return CreateResult(200, newProject.ToApi());
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] Models.Project project)
    {
        var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);

        if (existingProject == null)
        {
            return CreateResult(404, "Project not found");
        }

        existingProject.Cost = project.Cost;
        existingProject.State = project.State;

        await _context.SaveChangesAsync();

        return CreateResult(200, existingProject.ToApi());
    }

    [HttpGet("byStates")]
    public async Task<IActionResult> ByStates()
    {
        var projects = await _context.Projects
        .Include(p => p.ProjectState)
        .Where(p => p.IsArchived == false)
        .GroupBy(p => p.ProjectState.Name)
        .Select(g => new
        {
            State = g.Key,
            Count = g.Count()
        })
        .ToListAsync();

        return CreateResult(200, projects);
    }

    [HttpGet("byTypes")]
    public async Task<IActionResult> ByTypes()
    {
        var projects = await _context.Projects
        .Include(p => p.ProjectType)
        .Where(p => p.IsArchived == false)
        .GroupBy(p => p.ProjectType.Name)
        .Select(g => new
        {
            Type = g.Key,
            Total = g.Sum(p => p.Cost)
        })
        .ToListAsync();

        return CreateResult(200, projects);
    }

    [HttpPut("archive")]
    public async Task<IActionResult> Archive()
    {

        var currentDate = DateOnly.FromDateTime(DateTime.Now);

        var projects = await _context.Projects.Where(p => p.State == 3 && p.IsArchived == false).ToListAsync();

        var lastClosingLog = await _context.ClosingLogs.OrderByDescending(c => c.Date).FirstOrDefaultAsync();

        if (lastClosingLog != null && lastClosingLog.Date == currentDate)
        {
            return CreateResult(400, "Ya se ha realizado el cuadre el día de hoy");
        }

        foreach (var project in projects)
        {
            project.IsArchived = true;
        }

        var newClosingLog = new ClosingLog
        {
            Date = currentDate
        };

        _context.ClosingLogs.Add(newClosingLog);
        await _context.SaveChangesAsync();

        return CreateResult(200, "Cuadre realizado correctamente");
    }
}