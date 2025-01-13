using System.Reflection.Metadata.Ecma335;
using ProductionReadyArrayListAPI.Project.Domain.Entities;
using ProductionReadyArrayListAPI.Project.Domain.Enums;
using Project.Domain.Dto.TodoItem;

namespace Project.Domain.Mappers;

public static class TodoItemMapper
{
    public static TodoItemDto ToDto(this TodoItem entity)
    {
        return new TodoItemDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            DeadLine = entity.DeadLine,
            UserId = entity.User.Id,
            Username = entity.User.Name,
            Status = entity.Status.ToString(),
            CreatedAt = entity.CreatedAt
        };
    }

    public static TodoItem ToEntity(this CreateTodoItemDto dto)
    {
        return new TodoItem
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            DeadLine = dto.DeadLine,
            Status = StatusTask.Pending,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }

    public static TodoItem UpdateModel(this TodoItem model, UpdateTodoItemDto dto)
    {
        model.Name = string.IsNullOrEmpty(dto.Name) ? model.Name : dto.Name;
        model.Description = string.IsNullOrEmpty(dto.Description) ? model.Description : dto.Description;
        model.DeadLine = dto.DeadLine;
        model.Status = Enum.Parse<StatusTask>(dto.Status);
        model.UpdatedAt = DateTime.UtcNow;
        return model;
    }
}