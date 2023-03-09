using AutoMapper;
using UserService.BLL.DTOs;
using UserService.DAL.Entities;

namespace UserService.BLL.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UpdateUserDto, UserDto>();
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UserDto, User>();
    }
}