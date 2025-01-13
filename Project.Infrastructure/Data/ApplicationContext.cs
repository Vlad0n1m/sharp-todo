using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductionReadyArrayListAPI.Project.Domain.Entities;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public ApplicationContext() : base()
    {
        Database.EnsureCreated();
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory());
        var config = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlite(config.GetConnectionString("Sqlite"));
    }
}