using Project.Domain.Dto.TodoItem;

namespace Project.Infrastructure.Dto.User;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get;  set; }
    public string Email { get;  set; }
    
    public List<TodoItemDto>? TodoItems { get; set; }

}