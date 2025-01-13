namespace Project.Domain.Dto.TodoItem;

public class UpdateTodoItemDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DeadLine { get; set; }

    public string Status { get; set; }
    
    
}