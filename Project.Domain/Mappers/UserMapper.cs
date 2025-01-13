using ProductionReadyArrayListAPI.Project.Domain.Entities;
using Project.Infrastructure.Dto.User;

namespace Project.Domain.Mappers;

public static class UserMapper
{
    public static UserDto ToUserDto(this User userModel)
    {
        return new UserDto
        {
            Id = userModel.Id,
            Name = userModel.Name,
            Email = userModel.Email,
            TodoItems = userModel.TodoItems?.Select(t => t.ToDto()).ToList() 
        };
    }

    public static User ToUserFromDto(this CreateUserRequestDto userDto)
    {
        return new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            PasswordHash = userDto.PasswordHash
        };
    }
    
    
    
}