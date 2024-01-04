using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.EntityConfigs;
using TWJobs.Core.Models;

namespace TWJobs.Core.Data.Contexts;

public class TWJobsDbContext : DbContext
{
    public DbSet<Job> Jobs => Set<Job>();

    private readonly IConfiguration _configuration;

    public TWJobsDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));
        builder.UseMySql(_configuration.GetConnectionString("Default"), serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new JobEntityConfig());
    }
}