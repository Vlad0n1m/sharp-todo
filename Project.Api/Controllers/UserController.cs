using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Mappers;
using Project.Infrastructure.Dto.User;

namespace Project.Api;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationContext _context;

    public UserController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _context.Users
            .Include(u => u.TodoItems)
            .ToList()
            .Select(u => u.ToUserDto());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var user = _context.Users
            .Include(u => u.TodoItems) // Eagerly load TodoItems
            .FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.ToUserDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserRequestDto userDto)
    {
        var userModel = userDto.ToUserFromDto();
        _context.Users.Add(userModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var userModel = _context.Users.Find(id);
        _context.Users.Remove(userModel);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserRequestDto userDto)
    {
        var userModel = _context.Users.Include(u => u.TodoItems).ToList().FirstOrDefault(u=>u.Id==id);
        if (userModel == null)
        {
            return NotFound();
        }

            userModel.Name = userDto.Name;
            userModel.Email = userDto.Email;
        userModel.PasswordHash = userDto.PasswordHash;
        _context.SaveChanges();

        return Ok(userModel.ToUserDto());
    }
}