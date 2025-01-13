using ProductionReadyArrayListAPI.Project.Domain.Entities;
using ProductionReadyArrayListAPI.Project.Domain.Enums;

namespace Project.Domain.Dto.TodoItem;

public class TodoItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DeadLine { get; set; }

    public int UserId { get; set; }
    
    public string Username { get; set; }
    
    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }
    
}
