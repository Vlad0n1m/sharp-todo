using ProductionReadyArrayListAPI.Project.Domain.Enums;

namespace Project.Domain.Dto.TodoItem;

public class UpdateTodoItemRequestDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DeadLine { get; set; }

    public StatusTask Status { get; set; }
    
    public int UserId { get; set; }
}