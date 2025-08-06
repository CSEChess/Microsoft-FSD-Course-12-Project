using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SkillSnap.Api.Data;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly SkillSnapContext _context;
    private readonly IMemoryCache _cache;

    public ProjectsController(SkillSnapContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        if (!_cache.TryGetValue("projects", out List<Project>? projects))
        {
            projects = await _context.Projects
                .AsNoTracking()
                .ToListAsync();

            _cache.Set("projects", projects, TimeSpan.FromMinutes(5));
        }

        return Ok(projects);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        _cache.Remove("projects"); // Invalidate cache on add
        return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
    }
}