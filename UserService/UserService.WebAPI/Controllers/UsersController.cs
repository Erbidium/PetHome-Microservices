using Microsoft.AspNetCore.Mvc;
using UserService.BLL.DTOs;
using UserService.BLL.Services.Interfaces;

namespace UserService.WebAPI.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> Get(Guid id)
    {
        return Ok(await _userService.GetUserById(id));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromForm] CreateUserDto newUser)
    {
        await _userService.CreateUser(newUser);
        return Ok();
    }

    [HttpDelete("{userId:guid}")]
    public async Task<ActionResult> DeleteUser(Guid userId)
    {
        await _userService.DeleteUser(userId);
        return Ok();
    }
    
    [HttpPut("{userId:guid}")]
    public async Task<ActionResult> UpdateUser([FromForm] UpdateUserDto newUserData, Guid userId)
    {
        await _userService.UpdateUser(newUserData, userId);
        return Ok();
    }
}