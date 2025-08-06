using System.Net.Http;
using System.Net.Http.Json;
using SkillSnap.Api.Models; // ✅ Use models directly from Api project

namespace SkillSnap.Client.Services;

public class ProjectService
{
    private readonly HttpClient _httpClient;

    public ProjectService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Project>> GetProjectsAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Project>>("https://localhost:7210/api/projects");
        return result ?? new List<Project>();
    }

    public async Task AddProjectAsync(Project newProject)
    {
        await _httpClient.PostAsJsonAsync("https://localhost:7210/api/projects", newProject);
    }
}