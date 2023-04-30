using Microsoft.AspNetCore.Mvc;
using RequestService.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.BLL.DTOs;
using UserService.BLL.Services.Interfaces;
using UserService.WebAPI.Sync;

namespace UserService.WebAPI.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly HttpSyncClient _httpClient;

    public UsersController(IUserService userService, HttpSyncClient httpClient)
    {
        _userService = userService;
        _httpClient = httpClient;
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

    [HttpGet("with-adverts/{id:guid}")]
    public async Task<ActionResult<UserWithAdvertsDTO>> GetWithAdvert(Guid id)
    {
        UserDto userDTO = await _userService.GetUserById(id);
        List<AdvertDTO> userAdverts = await _httpClient.GetAdvertsByOwnerIDAsync(id.ToString());
        UserWithAdvertsDTO userWithAdverts = new()
        {
            Id = userDTO.Id,
            Name = userDTO.Name,
            Email = userDTO.Email,
            Location = userDTO.Location,
            PublishedAdverts = userAdverts
        };
        return Ok(userWithAdverts);
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