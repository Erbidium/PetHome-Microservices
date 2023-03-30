using UserService.BLL.DTOs;

namespace UserService.BLL.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetUsers();
    Task<UserDto> GetUserById(Guid id);
    Task CreateUser(CreateUserDto user);
    Task DeleteUser(Guid userId);
    Task UpdateUser(UpdateUserDto newUserData, Guid userId);
}