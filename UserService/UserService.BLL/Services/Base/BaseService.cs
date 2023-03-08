using AutoMapper;
using UserService.DAL.Interfaces;

namespace UserService.BLL.Services.Base;

public class BaseService
{
    private protected readonly IUserRepository UserRepository;
    private protected readonly IMapper Mapper;

    public BaseService(IUserRepository repo,IMapper mapper)
    {
        UserRepository = repo;
        Mapper = mapper;
    }
}
