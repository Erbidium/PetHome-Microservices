using UserService.BLL.DTOs;

namespace UserService.BLL.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetUsers();
    Task<UserDto> GetUserById(long id);
    Task CreateUser(CreateUserDto user);
    Task DeleteUser(long userId);
    Task UpdateUser(UserDto newUserData, long userId);
}