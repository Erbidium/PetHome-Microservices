using AdvertService.DAL.Interfaces;
using AutoMapper;


namespace AdvertService.BLL.Services.Base
{
    public class BaseService
    {
        private protected readonly IAdvertsRepository _advertsRepository;
        private protected readonly IMapper _mapper;
        public BaseService(IAdvertsRepository repo,IMapper mapper)
        {
            _advertsRepository = repo;
            _mapper = mapper;
        }
    }
}
