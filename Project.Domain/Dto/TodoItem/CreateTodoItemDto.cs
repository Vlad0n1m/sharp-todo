using ProductionReadyArrayListAPI.Project.Domain.Entities;
using ProductionReadyArrayListAPI.Project.Domain.Enums;

namespace Project.Domain.Dto.TodoItem;

public class CreateTodoItemDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DeadLine { get; set; }
    
    
    public int UserId { get; set; }

}