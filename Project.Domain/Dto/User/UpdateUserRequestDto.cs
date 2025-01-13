namespace Project.Infrastructure.Dto.User;

public class UpdateUserRequestDto
{
    public string Name { get;  set; }
    public string Email { get;  set; }
    public string PasswordHash { get;  set; }
}
