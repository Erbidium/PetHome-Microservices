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
        var newUser = Mapper.Map<User>(user);
        
        await UserRepository.Add(newUser);
        await UserRepository.SaveChangesAsync();
    }

    public async Task DeleteUser(long userId)
    {
        var user = await UserRepository.GetById(userId);
        if (user is null)
            throw new KeyNotFoundException("User is not found.");

        UserRepository.Delete(user);
        await UserRepository.SaveChangesAsync();
    }

    public async Task UpdateAdvert(UserDto newUserData, long userId)
    {
        var user = await UserRepository.GetById(userId);
        if (user is null)
            throw new KeyNotFoundException("User is not found.");

        Mapper.Map(newUserData, user);

        UserRepository.Update(user);
        await UserRepository.SaveChangesAsync();
    }
}