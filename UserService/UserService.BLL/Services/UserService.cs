using AutoMapper;
using UserService.BLL.DTOs;
using UserService.BLL.Services.Base;
using UserService.BLL.Services.Interfaces;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.BLL.Services;

public class UserService: BaseService, IUserService
{
    public UserService(IUserRepository userRepository, IMapper mapper)
        : base(userRepository, mapper) { }

    public async Task<List<UserDto>> GetUsers()
    {
        var users = await UserRepository.Get();
        return Mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto> GetUserById(long id)
    {
        if (await UserRepository.GetById(id) is not { } user)
            throw new KeyNotFoundException("User is not found");

        return Mapper.Map<UserDto>(user);
    }

    public async Task CreateUser(CreateUserDto user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteUser(long userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAdvert(UserDto newUserData, long userId)
    {
        throw new NotImplementedException();
    }
}