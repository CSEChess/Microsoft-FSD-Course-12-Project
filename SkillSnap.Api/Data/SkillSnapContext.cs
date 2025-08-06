using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Data;

public class SkillSnapContext : IdentityDbContext<ApplicationUser>
{
    public SkillSnapContext(DbContextOptions<SkillSnapContext> options) : base(options)
    {
    }

    public DbSet<PortfolioUser> PortfolioUsers => Set<PortfolioUser>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Skill> Skills => Set<Skill>();
}