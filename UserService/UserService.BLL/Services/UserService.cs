﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserService.BLL.DTOs;
using UserService.BLL.Services.Base;
using UserService.BLL.Services.Interfaces;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.BLL.Services;

public class UserService: BaseService, IUserService
{
    private PasswordHasher<User> _passwordHasher = new();

    public UserService(IUserRepository userRepository, IMapper mapper)
        : base(userRepository, mapper) { }

    public async Task<List<UserDto>> GetUsers()
    {
        var users = await UserRepository.Get();
        return Mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto> GetUserById(Guid id)
    {
        if (await UserRepository.GetById(id) is not { } user)
            throw new KeyNotFoundException("User is not found");

        return Mapper.Map<UserDto>(user);
    }

    public async Task CreateUser(CreateUserDto user)
    {
        var newUser = Mapper.Map<User>(user);
        
        var hashedPassword = _passwordHasher.HashPassword(newUser, user.Password);
        newUser.Password = hashedPassword;
        
        await UserRepository.Add(newUser);
        await UserRepository.SaveChangesAsync();
    }

    public async Task DeleteUser(Guid userId)
    {
        var user = await UserRepository.GetById(userId);
        if (user is null)
            throw new KeyNotFoundException("User is not found.");

        UserRepository.Delete(user);
        await UserRepository.SaveChangesAsync();
    }

    public async Task UpdateUser(UpdateUserDto newUserData, Guid userId)
    {
        var user = await UserRepository.GetById(userId);
        if (user is null)
            throw new KeyNotFoundException("User is not found.");

        Mapper.Map(newUserData, user);

        UserRepository.Update(user);
        await UserRepository.SaveChangesAsync();
    }
}