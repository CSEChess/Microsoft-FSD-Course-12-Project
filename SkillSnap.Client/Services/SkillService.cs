using System.Net.Http;
using System.Net.Http.Json;
using SkillSnap.Api.Models; // Confirm this after adding project reference from Client to Api

namespace SkillSnap.Client.Services;

public class SkillService
{
    private readonly HttpClient _httpClient;

    public SkillService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Skill>> GetSkillsAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Skill>>("https://localhost:7210/api/skills");
        return result ?? new List<Skill>();
    }

    public async Task AddSkillAsync(Skill newSkill)
    {
        await _httpClient.PostAsJsonAsync("https://localhost:7210/api/skills", newSkill);
    }
}