using AutoMapper;
using UserService.DAL.Entities;

namespace UserService.BLL.MappingProfiles
{
    public class UserWithAdvertProfile: Profile
    {
        public UserWithAdvertProfile()
        {
            CreateMap<User, UserWithAdvertProfile>();
            CreateMap<User, UserWithAdvertProfile>();
        }
    }
}
