using ProductionReadyArrayListAPI.Project.Domain.Enums;

namespace ProductionReadyArrayListAPI.Project.Domain.Entities;

public class TodoItem
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DeadLine { get; set; }

    public StatusTask Status { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
}