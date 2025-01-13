using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductionReadyArrayListAPI.Project.Domain.Entities;
using Project.Domain.Dto.TodoItem;
using Project.Domain.Mappers;

namespace Project.Api;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ApplicationContext _context;

    public TaskController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetAllUserTodoItems([FromRoute] int userId)
    {
        if (_context.Users.Find(userId) == null)
        {
            return NotFound();
        }
    
        var userTasks = _context.TodoItems.ToList().Where(i => i.UserId == userId).Select(i => i.ToDto()).ToList();
    
        return Ok(userTasks);
    }

    [HttpPost()]
    public IActionResult CreateTodoItem([FromBody] CreateTodoItemDto todoItemDto)
    {
        if (_context.Users.Find(todoItemDto.UserId) == null)
        {
            return NotFound();
        }

        var todoItemModel = todoItemDto.ToEntity();
        _context.TodoItems.Add(todoItemModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTaskByGuid), new {taskGuid = todoItemModel.Id}, todoItemModel.ToDto());
    }

    [HttpGet("{taskGuid}")]
    public IActionResult GetTaskByGuid([FromRoute] Guid taskGuid)
    {
        var todoItem = _context.TodoItems
            .Include(t => t.User) 
            .FirstOrDefault(t => t.Id == taskGuid);

        if (todoItem == null)
        {
            return NotFound();
        }

        return Ok(todoItem.ToDto());
    }
    
    [HttpDelete("{taskGuid}")]
    public IActionResult DeleteTaskByGuid([FromRoute] Guid taskGuid)
    {
        var todoItem = _context.TodoItems.FirstOrDefault(t => t.Id == taskGuid);

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        _context.SaveChanges();
        return Ok();
    }


    [HttpPut("{taskId}")]
    public IActionResult UpdateTodoItem([FromRoute] Guid taskId,
        [FromBody] UpdateTodoItemDto updateDto)
    {
        var todoItem = _context.TodoItems.FirstOrDefault(t => t.Id == taskId);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.UpdateModel(updateDto);
        _context.SaveChanges();
        return Ok();
    }
}